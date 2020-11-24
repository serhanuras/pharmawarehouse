import React, { useMemo } from 'react';
import { Link as RouterLink, useLocation, matchPath } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import navConfig from './navConfig';
import { NavbarWrapper, NavList, NavListItem, NavListItemIcon } from './styled';
import { Tooltip, Link } from '@material-ui/core';
import IconStore from 'src/App/components/IconStore';

const Navbar = () => {
  const { t } = useTranslation(['routes']);
  const location = useLocation();

  const navItems = useMemo(() => {
    return navConfig.map((item, i) => {
      const selected = matchPath(location.pathname, {
        path: item.pathname,
        exact: false
      });
      return (
        <Link
          key={i}
          to={{
            pathname: item.pathname,
            hash: location.state?.memorizedHash?.[item.pathname] || item.hash
          }}
          component={RouterLink}
        >
          <NavListItem button selected={Boolean(selected)}>
            <Tooltip title={t(item.description)} placement="right-end">
              <NavListItemIcon>
                <IconStore name={item.icon} />
              </NavListItemIcon>
            </Tooltip>
          </NavListItem>
        </Link>
      );
    });
  }, [location.pathname, location.state, t]);

  return (
    <NavbarWrapper>
      <NavList>{navItems}</NavList>
    </NavbarWrapper>
  );
};

export default Navbar;
