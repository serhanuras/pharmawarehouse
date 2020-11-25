import React, { useState } from 'react';
import { Redirect } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import {
  RouteWrapper,
  LogoWrapper,
  FormWrapper,
  FormItem,
  FormInputLabel,
  FormInputUserIcon,
  FormInputPasswordIcon,
  FormInput,
  FormLoginButton
} from './styled';

import { useKeypress } from 'src/tools/hooks';
import { loginRequest } from 'src/redux/actions/userActions';
import { Typography, InputAdornment } from '@material-ui/core';
import { useTranslation } from 'react-i18next';

const isEmptyString = (field) => field !== undefined && field === '';

export default () => {
  const { t } = useTranslation(['login', 'routes']);
  const user = useSelector(({ user }) => user);
  const [form, setForm] = useState({ username: undefined, password: undefined });
  const dispatch = useDispatch();

  const login = () => {
    if (!form.username || !form.password) {
      return setForm({ username: form.username || '', password: form.password || '' });
    }
    dispatch(
      loginRequest({
        username: form.username,
        password: form.password
      })
    );
  };

  useKeypress(['Enter'], login, form);

  const onInputChange = (e) => {
    setForm({ ...form, [e.target.id]: e.target.value });
  };

  if (user?.session) return <Redirect to="/" />;

  return (
    <RouteWrapper description={t('routes:login')}>
      <LogoWrapper />
      <FormWrapper>
        <FormItem>
          <FormInputLabel htmlFor="username">
            <Typography variant="body2">{t('username')}</Typography>
          </FormInputLabel>
          <FormInput
            id="username"
            type="email"
            onChange={onInputChange}
            error={isEmptyString(form.username) || user.responseError}
            startAdornment={<InputAdornment position="start">{<FormInputUserIcon />}</InputAdornment>}
          />
        </FormItem>
        <FormItem>
          <FormInputLabel htmlFor="password">
            <Typography variant="body2">{t('password')}</Typography>
          </FormInputLabel>
          <FormInput
            id="password"
            type="password"
            onChange={onInputChange}
            error={isEmptyString(form.password) || user.responseError}
            startAdornment={<InputAdornment position="start">{<FormInputPasswordIcon />}</InputAdornment>}
          />
        </FormItem>
        <FormItem>
          <FormLoginButton variant="contained" onClick={login} disabled={user.requestPending}>
            {t('login')}
          </FormLoginButton>
        </FormItem>
      </FormWrapper>
    </RouteWrapper>
  );
};
