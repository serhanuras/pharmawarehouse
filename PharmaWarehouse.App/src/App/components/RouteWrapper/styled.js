import { Box, withStyles } from '@material-ui/core';

const StyledRouteWrapper = withStyles((theme) => ({
  root: {
    padding: theme.spacing(5, 5, 3, 13)
  }
}))(Box);

export { StyledRouteWrapper };
