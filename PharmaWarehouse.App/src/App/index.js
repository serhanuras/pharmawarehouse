import React from 'react';
import { useTranslation } from 'react-i18next';
import { Switch, Route } from 'react-router-dom';

import Login from 'src/App/routes/Login';
import Layout from 'src/App/layout';
import { Helmet } from 'react-helmet';

const App = () => {
  const { i18n } = useTranslation();

  return (
    <>
      <Helmet>
        <html lang={i18n.language} />
      </Helmet>
      <Switch>
        <Route exact path="/login" component={Login} />
        <Route component={Layout} />
      </Switch>
    </>
  );
};

export default App;
