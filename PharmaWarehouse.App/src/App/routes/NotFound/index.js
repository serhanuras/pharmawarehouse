import React from 'react';
import { useTranslation } from 'react-i18next';
import RouteWrapper from 'src/App/components/RouteWrapper';
import { Typography } from '@material-ui/core';
import { useLocation } from 'react-router-dom';

export default () => {
  const { t } = useTranslation(['routes']);
  const location = useLocation();
  return (
    <RouteWrapper description={t('routes:not-found')}>
      <Typography variant="h3" style={{ textAlign: 'center', marginTop: 250 }}>
        {t('Sayfa bulunamadı  ')}
        {location.pathname}
      </Typography>
    </RouteWrapper>
  );
};
