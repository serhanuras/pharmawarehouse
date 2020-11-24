import i18n from 'i18next';
import LanguageDetector from 'i18next-browser-languagedetector';
import XHR from 'i18next-xhr-backend';
import { translation } from 'src/config';
i18n
  .use(XHR)
  .use(LanguageDetector)
  .init({
    lng: localStorage.getItem('i18nextLng') || translation.defaultLanguage,
    fallbackLng: translation.defaultLanguage, // use en if detected lng is not available
    keySeparator: false, // we do not use keys in form messages.welcome
    interpolation: {
      escapeValue: false // react already safes from xss
    },
    // defaultNS: 'translation',
    // auto load all translation files
    backend: {
      loadPath: '/locales/{{lng}}/{{ns}}.json'
    }
    // react: {
    //   wait: false,
    //   useSuspense: true //   <---- this will do the magic
    // }
  });

export default i18n;
