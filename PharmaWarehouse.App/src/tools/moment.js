import i18n  from './i18n';
import moment from 'moment';
import 'moment/locale/tr';

moment.locale(localStorage.getItem('i18nextLng') || i18n.defaultLanguage);
