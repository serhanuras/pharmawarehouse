import React, { Suspense, useEffect } from 'react';
import ScrollPositionManager from 'src/App/components/ScrollPositionManager';
import Header from './Appbar';
import Main from './Main';
import Navbar from './Navbar';
import { useHistory } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { LayoutWrapper } from './styled';
const Layout = () => {
  const history = useHistory();
  const user = useSelector(({ user }) => user);

  useEffect(() => {
    if (!user.session) {
      history.push('/login');
    }
  }, [user.session, history]);

  return (
    <ScrollPositionManager scrollKey={history.location.pathname + history.location.hash}>
      {() => (
        <LayoutWrapper>
          <Header />
          <Navbar />
          <Suspense fallback={null}>
            <Main />
          </Suspense>
        </LayoutWrapper>
      )}
    </ScrollPositionManager>
  );
};

export default Layout;
