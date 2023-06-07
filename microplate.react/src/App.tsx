import { Suspense } from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import ErrorBoundary from 'Components/ErrorBoundary/ErrorBoundary';
import Spinner from 'Components/Spinner/Spinner';
import store from 'Store';
import { Provider } from 'react-redux';
import './App.css';
import Dashboard from './Pages/Dashboard/Dashboard';
import Login from './Pages/Login/Login';

export default function App() {
  const { accessToken } = store.getState().auth.user;
  if (!accessToken) {
    return <ErrorBoundary>
      <Provider store={store}>
        <Suspense fallback={() => <Spinner />}>
          <Login />
        </Suspense>
      </Provider >
    </ErrorBoundary >

  }

  return (
    <ErrorBoundary>
      <Provider store={store}>
        <div className="wrapper">
          <h1>Application</h1>
          <BrowserRouter>
            <Route path="/dashboard">
              <Dashboard />
            </Route>
            <Route path="/preferences">
              {/* <Preferences /> */}
            </Route>
          </BrowserRouter>
        </div>
      </Provider>
    </ErrorBoundary>
  );
}
