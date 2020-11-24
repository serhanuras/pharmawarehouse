import React from 'react';
import PropTypes from 'prop-types';

import Home from './icons/HomeIcon';
import Settings from './icons/SettingsIcon';

import {
  Clear,
  Brightness4,
  BrightnessHigh,
  Input,
  Language,
  ExpandMore,
  ExpandLess,
  Dashboard as Default,
  SignalCellularNoSim,
  Person
} from '@material-ui/icons';

const iconMap = {
  //Custom Icons
  HomeIcon: Home,
  SettingsIcon: Settings,
  //Mui Icons
  Brightness4Icon: Brightness4,
  BrightnessHighIcon: BrightnessHigh,
  ClearIcon: Clear,
  InputIcon: Input,
  LanguageIcon: Language,
  ExpandMoreIcon: ExpandMore,
  ExpandLessIcon: ExpandLess,
  SignalCellularNoSimIcon: SignalCellularNoSim,
  PersonIcon: Person,
  DefaultIcon: Default
};

const IconStore = ({ name, ...rest }) => {
  const Icon = iconMap[name] || iconMap['DefaultIcon'];
  return <Icon {...rest} />;
};

IconStore.propTypes = {
  name: PropTypes.string.isRequired
};

export default IconStore;
