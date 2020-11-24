import React, { useMemo } from 'react';
import { useLocation } from 'react-router';
import { Link as RouterLink, useParams } from 'react-router-dom';
import { Link, Breadcrumbs } from '@material-ui/core';
import { useTranslation } from 'react-i18next';

const BreadCrumbs = () => {
  const { t } = useTranslation('routes');
  const location = useLocation();
  const params = Object.values(useParams());

  const pathnames = useMemo(() => location.pathname.split('/').filter((p) => p && !params.includes(p)), [
    location,
    params
  ]);

  const breadcrumbs = useMemo(
    () =>
      pathnames.map((pathname, i) => {
        return (
          <Link color="inherit" key={i} component={RouterLink} to={`/${pathnames.slice(0, i + 1).join('/')}`}>
            {t(pathname)}
          </Link>
        );
      }),
    [pathnames, t]
  );

  return (
    <Breadcrumbs style={{ color: '#fff' }} separator="/" aria-label="breadcrumb">
      <Link underline="always" component={RouterLink} color="inherit" to="/">
        <img alt="nav-item" src="/images/home_ic.svg" />
      </Link>
      {breadcrumbs}
    </Breadcrumbs>
  );
};

export default BreadCrumbs;
