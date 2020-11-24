import { Box, withStyles } from '@material-ui/core';

const LayoutWrapper = withStyles((theme) => ({
  root: {
    minHeight: '100vh',
    borderRight: `1px solid ${theme.palette.divider}`
  }
}))(Box);

export { LayoutWrapper };
