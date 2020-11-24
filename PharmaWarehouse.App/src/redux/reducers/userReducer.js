import produce from 'immer';
import { Types } from 'src/redux/actions/userActions';

const initialState = {
  session: JSON.parse(localStorage.getItem('session')),
  requestPending: undefined,
  responseError: undefined
};

export default (state = initialState, action) =>
  produce(state, (draft) => {
    switch (action.type) {
      case Types.LOGIN_REQUEST: {
        draft.requestPending = true;
        draft.responseError = false;
        break;
      }
      case Types.LOGIN_RESPONSE_SUCCESS: {
        localStorage.setItem('session', JSON.stringify(action.payload));
        draft.session = action.payload;
        draft.responseError = false;
        break;
      }
      case Types.LOGIN_RESPONSE_ERROR: {
        draft.responseError = true;
        draft.requestPending = false;
        break;
      }
      case Types.REMOVE_SESSION: {
        localStorage.removeItem('session');
        draft.session = undefined;
        break;
      }
      default:
        break;
    }
  });
