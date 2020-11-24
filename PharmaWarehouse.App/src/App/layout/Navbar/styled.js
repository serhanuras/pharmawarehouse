import { withStyles } from '@material-ui/core/styles';
import { Box, List, ListItem, ListItemIcon } from '@material-ui/core';

const NavbarWrapper = withStyles((theme) => ({
  root: {
    position: 'fixed',
    top: '30%',
    zIndex: 19,
    overflow: 'hidden',
    background: theme.palette.primary.main,
    width: 62,
    borderTopRightRadius: 5,
    borderBottomRightRadius: 5
  }
}))(Box);

const NavList = withStyles((theme) => ({
  root: {
    '& .Mui-selected': {
      backgroundColor: '#ffffff60',
      '&:hover': {
        backgroundColor: '#ffffff60'
      }
    }
  }
}))(List);

const NavListItem = withStyles((theme) => ({
  root: {
    paddingTop: theme.spacing(2),
    paddingBottom: theme.spacing(2)
  }
}))(ListItem);

const NavListItemIcon = withStyles((theme) => ({
  root: {
    minWidth: 30,
    minHeight: 30
  }
}))(ListItemIcon);

export { NavbarWrapper, NavList, NavListItem, NavListItemIcon };
