export default {
  '@global': {
    html: { overflowY: 'scroll' },
    body: { minWidth: 960 },
    '*::-webkit-scrollbar-track': {
      backgroundColor: 'transparent'
    },
    '*::-webkit-scrollbar': {
      width: '10px'
    },
    '*::-webkit-scrollbar-thumb': {
      backgroundColor: '#70adb473',
      borderRadius: '1ex'
    },
    'input[type=number]::-webkit-inner-spin-button ,input[type=number]::-webkit-outer-spin-button': {
      appearance: 'none',
      margin: 0
    }
  }
};
