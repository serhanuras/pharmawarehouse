import moment from 'moment';
import _ from 'lodash';

export const getInitials = (name = '') => {
  return name
    .replace(/\s+/, ' ')
    .split(' ')
    .slice(0, 2)
    .map((v) => v && v[0].toUpperCase())
    .join('');
};

export const getCurrencySymbol = (value = '') => {
  switch (value) {
    case 'TRY':
      return '₺';
    case 'USD':
      return '$';
    case 'EUR':
      return '€';
    case 'GBP':
      return '£';
    case 'CHF':
      return 'CHF';
    default:
      return value;
  }
};

export const bytesToSize = (bytes, decimals = 2) => {
  if (bytes === 0) return '0 Bytes';

  const k = 1024;
  const dm = decimals < 0 ? 0 : decimals;
  const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];

  const i = Math.floor(Math.log(bytes) / Math.log(k));

  return `${parseFloat((bytes / Math.pow(k, i)).toFixed(dm))} ${sizes[i]}`;
};

export const formatDate = (date) => {
  return moment(date).format('DD MMM YYYY') === 'Invalid date' ? '--/--/--' : moment(date).format('DD MMM YYYY');
};

export const formatFullDate = (date) => {
  return moment(date).format('DD MMM YYYY') === 'Invalid date' ? '--/--/--' : moment(date).format('DD MMM YYYY HH:mm');
};

export const formatDateWithUtc = (date) => {
  return moment.utc(date).format('DD MMM YYYY') === 'Invalid date' ? '--/--/--' : moment(date).format('DD MMM YYYY');
};

export const formatYear = (date) => {
  return moment(date).format('YYYY') === 'Invalid date' ? '--/--/--' : moment(date).format('YYYY');
};

export const formatDayMonth = (date) => {
  return moment(date).format('DD MMM') === 'Invalid date' ? '--/--/--' : moment(date).format('DD MMM');
};

export const getFirstLetters = (string = '', seperator = ' ') => string.split(seperator).map((word) => word.charAt(0));

export const getFirstLettersWithId = (string = '', seperator = ' ') =>
  string
    .slice(string.lastIndexOf('-') + 1)
    .split(seperator)
    .map((word) => word.charAt(0));

export const ConvertNumberToCurrencyFormat = (value, localization, currencyType) =>
  new Intl.NumberFormat(localization, {
    style: 'currency',
    currency: currencyType
  }).format(value);

export const makeJSDateObject = (date) => {
  if (date instanceof moment) {
    return date.clone().toDate();
  }
  if (moment.isMoment(date)) {
    return date.clone().toDate();
  }
  if (date instanceof moment) {
    return date.toJSDate();
  }
  if (date instanceof moment) {
    return new moment(date.getTime());
  }
  return date;
};

export const searchString = (target = '', string = '') => {
  return target.toLocaleUpperCase().replace(/\s/g, '').includes(string.replace(/\s/g, '').toLocaleUpperCase());
};

export const memorySizeOf = (obj) => {
  var bytes = 0;

  function sizeOf(obj) {
    if (obj !== null && obj !== undefined) {
      switch (typeof obj) {
        case 'number':
          bytes += 8;
          break;
        case 'string':
          bytes += obj.length * 2;
          break;
        case 'boolean':
          bytes += 4;
          break;
        case 'object':
          var objClass = Object.prototype.toString.call(obj).slice(8, -1);
          if (objClass === 'Object' || objClass === 'Array') {
            for (var key in obj) {
              if (!obj.hasOwnProperty(key)) continue;
              sizeOf(obj[key]);
            }
          } else bytes += obj.toString().length * 2;
          break;
        default:
          break;
      }
    }
    return bytes;
  }

  function formatByteSize(bytes) {
    if (bytes < 1024) return bytes + ' bytes';
    else if (bytes < 1048576) return (bytes / 1024).toFixed(3) + ' KiB';
    else if (bytes < 1073741824) return (bytes / 1048576).toFixed(3) + ' MiB';
    else return (bytes / 1073741824).toFixed(3) + ' GiB';
  }

  return formatByteSize(sizeOf(obj));
};

export const getPropByString = (obj, propString) => {
  if (!propString) return obj;

  let prop,
    props = propString.split('.');

  for (var i = 0, iLen = props.length - 1; i < iLen; i++) {
    prop = props[i];

    let candidate = obj[prop];
    if (candidate !== undefined) {
      obj = candidate;
    } else {
      break;
    }
  }
  return obj[props[i]];
};

export const setAttachmentsToLower = (attachments) => {
  let attachmentsLowerCase = [];

  attachments.forEach((item) => {
    attachmentsLowerCase.push({
      id: item.Id,
      name: item.Name,
      size: item.Size
    });
  });

  return attachmentsLowerCase;
};

export const setAttachmentsToUpper = (attachments) => {
  let attachmentsLowerCase = [];

  attachments.forEach((item) => {
    attachmentsLowerCase.push({
      Id: item.id,
      Name: item.name,
      Size: item.size
    });
  });

  return attachmentsLowerCase;
};

// Capitalizes the first letter of the word
export const setUpperCase = (str) => {
  if (_.isEmpty(str)) {
    return str;
  } else {
    return str.toLowerCase().replace(/(?:^|\s)\S/g, (l) => l.toUpperCase());
  }
};

export const base64toBlob = (base64Data, contentType) => {
  contentType = contentType || '';
  var sliceSize = 1024;
  var byteCharacters = atob(base64Data);
  var bytesLength = byteCharacters.length;
  var slicesCount = Math.ceil(bytesLength / sliceSize);
  var byteArrays = new Array(slicesCount);

  for (var sliceIndex = 0; sliceIndex < slicesCount; ++sliceIndex) {
    var begin = sliceIndex * sliceSize;
    var end = Math.min(begin + sliceSize, bytesLength);

    var bytes = new Array(end - begin);
    for (var offset = begin, i = 0; offset < end; ++i, ++offset) {
      bytes[i] = byteCharacters[offset].charCodeAt(0);
    }
    byteArrays[sliceIndex] = new Uint8Array(bytes);
  }

  return new Blob(byteArrays, { type: contentType });
};
