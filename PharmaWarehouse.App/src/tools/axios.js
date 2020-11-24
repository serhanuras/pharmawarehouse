import axios from 'axios';
import { apiURL } from 'src/config';

const instance = axios.create({
  baseURL: apiURL,
  withCredentials: true
});

instance.interceptors.request.use((config) => {
  Object.assign(config.headers, { Authorization: `Bearer ${JSON.parse(localStorage.getItem('session'))?.token}` });
  if (config.data instanceof FormData) {
    Object.assign(config.headers, { 'Content-Type': 'multipart/form-data' });
  }
  return config;
});

instance.interceptors.response.use(
  (response) => {
    return Promise.resolve(response);
  },
  (error) => {
    console.error(error.response.data);
    if (401 === error.response.status) {
      localStorage.removeItem('session');
      window.location.href = '/login';
      return;
    }
    return Promise.reject(error);
  }
);

export default instance;
