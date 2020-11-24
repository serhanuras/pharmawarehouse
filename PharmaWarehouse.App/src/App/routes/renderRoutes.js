import React from 'react';
import { Route } from 'react-router-dom';

import ErrorBoundary from 'src/App/components/ErrorBoundary';

const renderRoutes = (routes = [], permittedRoutes = []) => {
  return (
    routes
      // .filter((route) => permittedRoutes.includes(route.path) || route.public)
      .map((route, i) => {
        return (
          <Route
            key={route.key || i}
            path={route.path}
            exact={route.exact}
            render={(props) => (
              <ErrorBoundary>
                <route.component {...props} />
              </ErrorBoundary>
            )}
          />
        );
      })
  );
};

export default renderRoutes;
