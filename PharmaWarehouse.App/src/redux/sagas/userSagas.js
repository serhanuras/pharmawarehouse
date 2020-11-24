import { takeEvery, call, put, fork } from 'redux-saga/effects';
import * as actions from 'src/redux/actions/userActions';
import * as services from 'src/services/userService';

function* loginRequest(action) {
  try {
    const { data } = yield call(services.login, action.payload);
    yield put(actions.loginResponseSuccess(data));
  } catch (error) {
    yield put(actions.loginResponseError(error));
  }
}

function* watchLoginRequest() {
  yield takeEvery(actions.Types.LOGIN_REQUEST, loginRequest);
}

const userSagas = [fork(watchLoginRequest)];

export default userSagas;
