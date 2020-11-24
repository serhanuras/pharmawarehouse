import axios from 'src/tools/axios';

export const login = ({ username, password }) => {
  return axios.post(`/login`, {
    username,
    password
  });
};
