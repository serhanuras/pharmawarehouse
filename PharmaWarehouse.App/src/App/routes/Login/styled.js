import { loginBackgroundSrc, logoSrc } from 'src/config';
import { Box, Paper, Button, Input, InputLabel, withStyles } from '@material-ui/core';

import Rc from 'src/App/components/RouteWrapper';
import PersonOutlineIcon from '@material-ui/icons/PersonOutline';
import LockIcon from '@material-ui/icons/Lock';

const RouteWrapper = withStyles((theme) => ({
  root: {
    height: '100vh',
    width: '100%',
    padding: 0,
    margin: 0,
    backgroundImage: `url("${loginBackgroundSrc}")`,
    backgroundSize: 'cover',
    backgroundRepeat: 'no-repeat',
    display: 'flex',
    flexDirection: 'row',
    justifyContent: 'center',
    flexWrap: 'wrap',
    alignItems: 'center'
  }
}))(Rc);

const LogoWrapper = withStyles((theme) => ({
  root: {
    margin: theme.spacing(3),
    width: '100%',
    height: '100%',
    maxWidth: 300,
    maxHeight: 200,
    backgroundRepeat: 'no-repeat',
    backgroundSize: 'contain',
    backgroundImage: `url("${logoSrc}")`
  }
}))(Box);

const FormWrapper = withStyles((theme) => ({
  root: {
    margin: theme.spacing(3),
    padding: theme.spacing(5),
    backgroundColor: 'rgba(255, 255, 255, 0.3)',
    backdropFilter: 'blur(10px)'
  }
}))(Paper);

const FormItem = withStyles((theme) => ({
  root: {
    margin: 'auto'
  }
}))(Box);

const FormInputLabel = withStyles((theme) => ({
  root: {
    marginLeft: theme.spacing(4),
    color: '#8a95a0'
  }
}))(InputLabel);

const FormInputUserIcon = withStyles({
  root: {
    color: '#8a95a0',
    width: 25,
    height: 25
  }
})(PersonOutlineIcon);

const FormInputPasswordIcon = withStyles((theme) => ({
  root: {
    color: '#8a95a0',
    width: 25,
    height: 25
  }
}))(LockIcon);

const FormInput = withStyles((theme) => ({
  root: {
    minWidth: 250,
    marginBottom: theme.spacing(5),
    borderBottomColor: '#8a95a0',
    color: theme.palette.common.black
  }
}))(Input);

const FormLoginButton = withStyles((theme) => ({
  root: {
    display: 'block',
    margin: 'auto',
    padding: theme.spacing(2, 6),
    backgroundColor: theme.palette.primary.main,
    color: theme.palette.primary.contrastText,
    '&:hover': { backgroundColor: theme.palette.secondary.main }
  }
}))(Button);

export {
  RouteWrapper,
  LogoWrapper,
  FormWrapper,
  FormItem,
  FormInputLabel,
  FormInputUserIcon,
  FormInputPasswordIcon,
  FormInput,
  FormLoginButton
};
