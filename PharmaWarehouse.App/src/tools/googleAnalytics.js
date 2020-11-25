import ReactGA from 'react-ga';

export const initGA = (trackingID) => {
  ReactGA.initialize(trackingID);
};

export const pageView = (page) => {
  ReactGA.pageview(page);
};

export const event = (category, action, label) => {
  ReactGA.event({
    category,
    action,
    label
  });
};
