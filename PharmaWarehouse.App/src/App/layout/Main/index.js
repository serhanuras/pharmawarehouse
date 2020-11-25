import React from 'react';
import { Switch } from 'react-router-dom';
import routes from 'src/App/routes/routes';
import renderRoutes from 'src/App/routes/renderRoutes';
import { MainWrapper } from './styled';

const Main = () => {
  return (
    <MainWrapper>
      <Switch>{renderRoutes(routes)}</Switch>
    </MainWrapper>
  );
};

export default Main;
