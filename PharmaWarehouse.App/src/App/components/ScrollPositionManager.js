import React from 'react';

export const memoryStore = {
  _data: new Map(),
  get(key) {
    if (!key) {
      return null;
    }

    return this._data.get(key) || null;
  },
  set(key, data) {
    if (!key) {
      return;
    }
    return this._data.set(key, data);
  }
};

/**
 * Component that will save and restore Window scroll position.
 */
export default class ScrollPositionManager extends React.Component {
  constructor(props) {
    super(...arguments);
    this.connectScrollTarget = this.connectScrollTarget.bind(this);
    this._target = window;
    this.resizeObserver = null;
    this.state = {
      resizedScrollKey: null,
      updatedScrollKey: null
    };
  }

  connectScrollTarget(node) {
    this._target = node;
  }

  restoreScrollPosition(pos) {
    pos = pos || this.props.scrollStore.get(this.props.scrollKey);
    if (this._target && pos) {
      scroll(this._target, pos.x, pos.y);
      this.setState({ updatedScrollKey: this.state.resizedScrollKey });
    }
  }

  saveScrollPosition(key) {
    if (this._target) {
      const pos = getScrollPosition(this._target);
      key = key || this.props.scrollKey;
      this.props.scrollStore.set(key, pos);
    }
  }

  componentDidMount() {
    this.resizeObserver = new ResizeObserver(() => {
      this.setState({ resizedScrollKey: this.props.scrollKey });
    });
    this.resizeObserver.observe(this._target.document.body);
  }

  componentDidUpdate() {
    if (this.state.resizedScrollKey !== this.state.updatedScrollKey) {
      this.restoreScrollPosition();
    }
  }

  UNSAFE_componentWillReceiveProps(nextProps) {
    if (this.props.scrollKey !== nextProps.scrollKey) {
      this.saveScrollPosition();
    }
  }

  componentWillUnmount() {
    this.saveScrollPosition();
    this.resizeObserver.disconnect();
  }

  render() {
    const { children = null, ...props } = this.props;
    return children && children({ ...props, connectScrollTarget: this.connectScrollTarget });
  }
}

ScrollPositionManager.defaultProps = {
  scrollStore: memoryStore
};

function scroll(target, x, y) {
  if (target instanceof window.Window) {
    target.scrollTo(x, y);
  } else {
    target.scrollLeft = x;
    target.scrollTop = y;
  }
}

function getScrollPosition(target) {
  if (target instanceof window.Window) {
    return { x: target.scrollX, y: target.scrollY };
  }

  return { x: target.scrollLeft, y: target.scrollTop };
}
