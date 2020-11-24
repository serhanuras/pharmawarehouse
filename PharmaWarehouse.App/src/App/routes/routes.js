import React from 'react';

import { Redirect } from 'react-router-dom';
import Dashboard from './Dashboard';
import ErrorReport from './ErrorReport';
import NotFound from './NotFound';
import WorkInProgress from './WorkInProgress';

export default [
  {
    path: '/',
    public: true,
    exact: true,
    component: () => <Redirect to="/dashboard" />
  },
  {
    path: '/dashboard',
    exact: true,
    component: Dashboard
  },
  {
    path: '/settings',
    exact: true,
    component: WorkInProgress
  },
  {
    path: '/error-report',
    exact: true,
    component: ErrorReport
  },
  {
    path: '/work-in-progress',
    component: WorkInProgress
  },
  {
    component: NotFound
  }
];
