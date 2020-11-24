// import uuid from 'uuid/v1';
// import moment from 'moment';
import { mock } from './_utils';

mock.onPost('/login').reply((req) => {
  console.log(req.data);
  return [
    200,
    {
      token:
        'eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiIzOTk5MTEzIiwiaXNSb290IjoiZmFsc2UifQ.OrfuH-cAVelvLP04fLlnBGUQdV-MWJkph2UqlWymlcSif7frQk2LN4e-4m671boZknebdh0Y7ljnIstVfat1tA',
      user: {
        id: 3999113,
        firstName: 'Customer',
        lastName: 'Mobile'
      }
    }
  ];
});
