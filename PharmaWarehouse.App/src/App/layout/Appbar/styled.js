import { AppBar, Avatar, withStyles } from '@material-ui/core';

const AppBarWrapper = withStyles((theme) => ({
  root: {}
}))(AppBar);
const UserAvatar = withStyles((theme) => ({
  root: {
    background: theme.palette.secondary.main
  }
}))(Avatar);

export { AppBarWrapper, UserAvatar };
