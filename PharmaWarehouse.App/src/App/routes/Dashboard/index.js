import React from 'react';
import { useTranslation } from 'react-i18next';
import RouteWrapper from 'src/App/components/RouteWrapper';
import { Box, Container } from '@material-ui/core';

export default () => {
  const { t } = useTranslation(['dashboard', 'routes']);

  return (
    <RouteWrapper description={t('routes:dashboard')}>
      <Container>
        <Box>{t('dashboard')}</Box>
      </Container>
    </RouteWrapper>
  );
};
