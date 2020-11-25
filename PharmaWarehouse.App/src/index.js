import 'react-app-polyfill/ie11';
import 'react-app-polyfill/stable';
import * as serviceWorker from './serviceWorker';
import React, { Suspense } from 'react';
import ReactDOM from 'react-dom';
import configureStore from 'src/redux/configureStore';
import { I18nextProvider } from 'react-i18next';
import { Provider } from 'react-redux';
import { MuiThemeProvider } from 'src/theme';
import { BrowserRouter } from 'react-router-dom';
import i18n from 'src/tools/i18n';
import App from 'src/App';
import 'src/tools/moment'
import 'src/services/mock'; //with mock service
const store = configureStore();

ReactDOM.render(
  <Suspense fallback={null}>
    <I18nextProvider i18n={i18n}>
      <Provider store={store}>
        <MuiThemeProvider>
          <BrowserRouter>
            <App />
          </BrowserRouter>
        </MuiThemeProvider>
      </Provider>
    </I18nextProvider>
  </Suspense>,
  document.getElementById('root')
);

serviceWorker.unregister();
