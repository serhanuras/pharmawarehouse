import { Box, styled } from '@material-ui/core';

const ImageWrapper = styled(Box)({
  textAlign: 'center',
  marginTop: 150
});

const Image = styled('img')({
  width: 300,
  height: 300
});

export { ImageWrapper, Image };
