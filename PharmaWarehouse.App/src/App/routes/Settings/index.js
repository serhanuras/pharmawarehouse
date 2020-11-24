import React from 'react';
import { useTranslation } from 'react-i18next';
import RouteWrapper from 'src/App/components/RouteWrapper';

export default () => {
  const { t } = useTranslation(['routes']);

  return (
    <RouteWrapper description={t('routes:settings')}>
      <div>
        <h1>Settings</h1>
      </div>
    </RouteWrapper>
  );
};
