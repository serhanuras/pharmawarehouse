import React from 'react';
import RouteWrapper from 'src/App/components/RouteWrapper';
import { useTranslation } from 'react-i18next';
import { ImageWrapper, Image } from './styled';
export default () => {
  const { t } = useTranslation(['routes']);

  return (
    <RouteWrapper description={t('routes:work-in-progress')}>
      <ImageWrapper>
        <Image src="/images/work-in-progress.png" alt="" />
      </ImageWrapper>
    </RouteWrapper>
  );
};
