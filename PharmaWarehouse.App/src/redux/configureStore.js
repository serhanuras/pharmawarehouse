import { applyMiddleware, compose, createStore } from 'redux';
import createSagaMiddleware from 'redux-saga';
import rootReducer from 'src/redux/reducers';
import rootSaga from 'src/redux/sagas';
import { isProduction } from 'src/config';
const sagaMiddleware = createSagaMiddleware();

export default (initialState) => {
  const middleware = [sagaMiddleware];
  const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
  const store = createStore(rootReducer, initialState, composeEnhancers(applyMiddleware(...middleware)));

  var sagaTask = sagaMiddleware.run(rootSaga);
  sagaTask.toPromise().catch((error) => {
    // Error here is a fatal error.
    // None of the sagas down the road caught it.
  });
  if (!isProduction && module.hot) {
    module.hot.accept('./reducers', () => store.replaceReducer(rootReducer));
  }

  return store;
};
