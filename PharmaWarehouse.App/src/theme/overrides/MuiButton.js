// import { colors } from '@material-ui/core';
import palette from '../palette';

export default {
  contained: {
    // boxShadow: '0 1px 1px 0 rgba(0,0,0,0.14)',
    // backgroundColor: palette.primary.main,
    // color: palette.primary.contrastText,
    // '&:hover': {
    //   backgroundColor: palette.primary.main
    // }
  },
  containedPrimary: {
    backgroundColor: palette.primary.main,
    color: palette.primary.contrastText,
    '&:hover': {
      backgroundColor: palette.primary.main
    }
  }
};
