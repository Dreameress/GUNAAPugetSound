import './styles/index.css';
import './styles/site.css';
import './styles/material.css';
import './styles/bootstrap.css';
import 'font-awesome/css/font-awesome.min.css'; 
import './styles/styles.less';


import React from 'react';
import { Router } from 'react-router-dom';
import { render } from 'react-dom';

import { history } from './helpers';
import { accountService } from './services';
import { App } from './App';

import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');



// attempt silent token refresh before startup
accountService.refreshToken().finally(startApp);

function startApp() {
  render(
    <Router history={history} basename={baseUrl}>
      <App />
    </Router>,
    rootElement);
}

registerServiceWorker();
