import React from 'react';
import { Redirect } from 'react-router-dom';

export default class ErrorBoundary extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: false,
      message: ''
    };
  }

  static getDerivedStateFromError(error) {
    return {
      error: true,
      message: error
    };
  }
  componentDidCatch(error, info) {
    console.error('[ ERROR BOUNDRY ]', error);
  }
  render() {
    if (this.state.error) {
      return <Redirect to={{ pathname: '/error-report', state: { errorMessage: this.state.message } }} />;
    }
    return this.props.children;
  }
}
