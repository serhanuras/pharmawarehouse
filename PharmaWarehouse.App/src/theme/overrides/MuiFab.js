import palette from '../palette';
export default {
  root: {
    backgroundColor: palette.common.white,
    boxShadow: '0 3px 7px 0 rgba(0, 0, 0, 0.13)',
    borderRadius: 10,
    borderColor: 'solid 1px #ebecf1',
    '&:hover': {
      backgroundColor: palette.action.hover
    }
  }
};
