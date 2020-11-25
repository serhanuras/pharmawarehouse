import React, { useState, useEffect, createContext } from 'react';
import { createMuiTheme } from '@material-ui/core';
import { ThemeProvider } from '@material-ui/styles';
// import StylesProvider from 'src/theme/StylesProvider';
import CssBaseline from '@material-ui/core/CssBaseline';

import palette from './palette';
import typography from './typography';
import overrides from './overrides';
import constants from './constants';

const MuiThemeContext = createContext(null);

const initialThemeType = localStorage.getItem('theme-type') || 'light';
const initialThemeDirection = localStorage.getItem('theme-direction') || 'ltr';

const getBackground = (themeType) => {
  const lightDefault = '#EDF2FA';
  const darkDefault = '#303030';
  const lightpaper = '#FFFFFF';
  const darkpaper = '#424242';
  return {
    default: themeType === 'light' ? lightDefault : darkDefault,
    paper: themeType === 'light' ? lightpaper : darkpaper
  };
};

const MuiThemeProvider = ({ children }) => {
  const [theme, setTheme] = useState({
    direction: initialThemeDirection,
    palette: {
      ...palette,
      type: initialThemeType,
      background: getBackground(initialThemeType)
    },
    typography,
    overrides,
    constants
  });

  useEffect(() => {
    localStorage.setItem('theme-type', theme.palette.type);
  }, [theme.palette.type]);

  useEffect(() => {
    localStorage.setItem('theme-direction', theme.direction);
  }, [theme.direction]);

  const changeThemeType = () => {
    setTheme((theme) => {
      const themeType = theme.palette.type === 'light' ? 'dark' : 'light';
      return {
        ...theme,
        palette: {
          ...theme.palette,
          type: themeType,
          background: getBackground(themeType)
        }
      };
    });
  };

  const changeThemeDirection = () => {
    setTheme((theme) => ({
      ...theme,
      direction: theme.direction === 'ltr' ? 'rtl' : 'ltr'
    }));
  };

  return (
    <MuiThemeContext.Provider value={{ theme, changeThemeType, changeThemeDirection }}>
      <ThemeProvider theme={createMuiTheme(theme)}>
        <CssBaseline />
        {/* ### rtl aktif etmek için StylesProvider ile wrap edilmesi gerekir ###  */}
        {/* <StylesProvider direction={theme.direction}>{children}</StylesProvider> */}
        {children}
      </ThemeProvider>
    </MuiThemeContext.Provider>
  );
};

export { MuiThemeProvider, MuiThemeContext };
