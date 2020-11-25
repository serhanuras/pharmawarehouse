import { colors } from '@material-ui/core';
// import gradient from 'src/utils/gradients';

const white = '#FFFFFF';

export default {
  type: 'light',
  primary: {
    contrastText: white,
    main: '#4a93a1'
  },
  secondary: {
    contrastText: white,
    main: '#70ADB4'
  },
  success: {
    contrastText: white,
    dark: colors.red[900],
    main: colors.green[600],
    light: colors.green[400]
  },
  error: {
    contrastText: white,
    dark: colors.red[900],
    main: '#d0021b',
    light: colors.red[400]
  },
  warning: {
    contrastText: white,
    dark: colors.orange[900],
    main: colors.orange[600],
    light: colors.orange[400]
  },

  background: {},
  common: {},
  action: {}
};
