import React from 'react';
import { useTranslation } from 'react-i18next';
import RouteWrapper from 'src/App/components/RouteWrapper';
import { Typography } from '@material-ui/core';

export default () => {
  const { t } = useTranslation(['routes']);

  return (
    <RouteWrapper description={t('routes:error-report')}>
      <Typography variant="h3" style={{ textAlign: 'center', marginTop: 250 }}>
        {t('error report')}
      </Typography>
    </RouteWrapper>
  );
};
