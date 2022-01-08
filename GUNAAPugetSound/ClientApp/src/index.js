import './../src/styles/index.css';
import './../src/styles/site.css';
import './../src/styles/material.css';
import './../src/styles/bootstrap.css';
import 'font-awesome/css/font-awesome.min.css';
import './../src/styles/styles.less';

import React from 'react';
import { Router } from 'react-router-dom';
import { render } from 'react-dom';

import { history } from './helpers';
import { accountService } from './services';
import { App } from './App';

import registerServiceWorker from './registerServiceWorker';

import repositoryReducer from './store/reducers/repositoryReducer';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';


const store = createStore(repositoryReducer, applyMiddleware(thunk));
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');



// attempt silent token refresh before startup
accountService.refreshToken().finally(startApp);

function startApp() {
  render(
    <Router history={history} basename={baseUrl}>
      <Provider store={store}>
        <App />
      </Provider>
    </Router>,
    rootElement);
}

registerServiceWorker();
