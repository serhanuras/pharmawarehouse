import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { translation } from 'src/config';
import moment from 'moment';
import { useMuiTheme } from 'src/theme/useMuiTheme';
import { Toolbar, Grid, Box, Typography, Menu, MenuItem, IconButton } from '@material-ui/core';
import { AppBarWrapper, UserAvatar } from './styled';
import IconStore from 'src/App/components/IconStore';

import { useDispatch, useSelector } from 'react-redux';
import { removeSession } from 'src/redux/actions/userActions';

const Header = () => {
  const { i18n } = useTranslation();
  const { theme, changeThemeType } = useMuiTheme();
  const [selectedIndex, setSelectedIndex] = useState(
    translation.languages.findIndex((lang) => lang.key === i18n.language)
  );
  const [anchorEl, setAnchorEl] = useState(null);

  const user = useSelector((state) => state.user.session?.user);

  const dispatch = useDispatch();

  const onLanguageChange = (event, index) => {
    setSelectedIndex(index);
    i18n.changeLanguage(translation.languages[index].key);
    moment.locale(translation.languages[index].key);
    setAnchorEl(null);
  };

  const logout = () => {
    dispatch(removeSession());
  };
  //TODO: styled
  return (
    <AppBarWrapper position="sticky" color="primary">
      <Toolbar variant="dense">
        <Grid container direction="row" justify="space-between" alignItems="center" wrap="nowrap">
          <Grid container item direction="row" justify="flex-start" alignItems="center" wrap="nowrap">
            <Grid item>
              <Box mr={1}>
                {user?.profileImage ? (
                  <UserAvatar variant="circle" alt={user?.firstName} src={user.profileImage} />
                ) : (
                  <UserAvatar variant="circle">
                    <IconStore name="PersonIcon" />
                  </UserAvatar>
                )}
              </Box>
            </Grid>
            <Grid item>
              <Box ml={1}>
                <Typography>{user?.firstName}</Typography>
              </Box>
            </Grid>
          </Grid>
          <Grid container item direction="row" justify="flex-end" alignItems="center" wrap="nowrap">
            <Grid item>
              <IconButton color="inherit" onClick={(event) => setAnchorEl(event.currentTarget)}>
                <IconStore name="LanguageIcon" />
              </IconButton>
            </Grid>
            <Grid item>
              <Menu
                id="lock-menu"
                anchorEl={anchorEl}
                keepMounted
                open={Boolean(anchorEl)}
                onClose={() => setAnchorEl(null)}
              >
                {translation.languages.map((option, index) => (
                  <MenuItem
                    key={index}
                    selected={index === selectedIndex}
                    onClick={(event) => onLanguageChange(event, index)}
                  >
                    {option.title}
                  </MenuItem>
                ))}
              </Menu>
            </Grid>
            <Grid item>
              <IconButton color="inherit" onClick={changeThemeType}>
                {theme.palette.type === 'light' ? (
                  <IconStore name="Brightness4Icon" />
                ) : (
                  <IconStore name="BrightnessHighIcon" />
                )}
              </IconButton>
            </Grid>
            <Grid item>
              <IconButton color="inherit" onClick={logout}>
                <IconStore name="InputIcon" />
              </IconButton>
            </Grid>
          </Grid>
        </Grid>
      </Toolbar>
    </AppBarWrapper>
  );
};

export default Header;
