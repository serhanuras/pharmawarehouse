export const Types = {
  LOGIN_REQUEST: 'LOGIN_REQUEST',
  LOGIN_RESPONSE_SUCCESS: 'LOGIN_RESPONSE_SUCCESS',
  LOGIN_RESPONSE_ERROR: 'LOGIN_RESPONSE_ERROR',

  REMOVE_SESSION: 'REMOVE_SESSION'
};

export const loginRequest = (payload) => ({ type: Types.LOGIN_REQUEST, payload });
export const loginResponseSuccess = (payload) => ({ type: Types.LOGIN_RESPONSE_SUCCESS, payload });
export const loginResponseError = (payload) => ({ type: Types.LOGIN_RESPONSE_ERROR, payload });

export const removeSession = () => ({ type: Types.REMOVE_SESSION });
