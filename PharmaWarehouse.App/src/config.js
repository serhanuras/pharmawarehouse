export const isProduction = process.env.REACT_APP_CUSTOM_NODE_ENV === 'production';
// export const isPreProduction = process.env.REACT_APP_CUSTOM_NODE_ENV === 'preproduction'
// export const isDevelopment = process.env.REACT_APP_CUSTOM_NODE_ENV === 'development';
// export const domain = process.env.REACT_APP_DOMAIN 
// export const appVersion = process.env.REACT_APP_APP_VERSION 
// export const pushServerPublicKey = process.env.REACT_APP_PUSH_SERVER_PUBLIC_KEY
// export const googleTrackingId = process.env.REACT_APP_GOOGLE_TRACKING_ID
export const apiURL = process.env.REACT_APP_API_URL;
export const logoSrc = process.env.REACT_APP_LOGO_SRC;
export const loginBackgroundSrc = process.env.REACT_APP_LOGIN_BACKGROUND_SRC;
export const trackingBackgroundSrc = process.env.REACT_APP_TRACKING_BACKGROUND_SRC;
export const translation = {
  languages: [
    {
      key: 'tr',
      flag: 'tr-TR',
      title: 'Türkçe'
    },
    {
      key: 'en',
      flag: 'en-US',
      title: 'English'
    }
  ],
  defaultLanguage: process.env.REACT_APP_DEFAULT_LANGUAGE
};
