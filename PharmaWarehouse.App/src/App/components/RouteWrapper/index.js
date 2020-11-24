import React from 'react';
import PropTypes from 'prop-types';
import { Helmet } from 'react-helmet';

// import { pageView } from 'src/utils/googleAnalytics';
// import { isProduction } from from 'src/config';

import { StyledRouteWrapper } from './styled';

const RouteWrapper = ({ description, children, ...rest }) => {
  // useEffect(() => {
  //   isProduction && pageView(`${location.pathname}${location.search}`);
  // }, [location]);

  return (
    <>
      <Helmet>
        <title>{description}</title>
      </Helmet>
      <StyledRouteWrapper {...rest}>{children}</StyledRouteWrapper>
    </>
  );
};

RouteWrapper.propTypes = {
  loading: PropTypes.bool,
  description: PropTypes.string,
  children: PropTypes.node.isRequired
};

export default RouteWrapper;
