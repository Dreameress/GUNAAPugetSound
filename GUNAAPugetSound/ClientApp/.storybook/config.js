import { configure } from '@storybook/react';

import '../src/styles/index.css';
import '../src/styles/site.css';
import '../src/styles/material.css';
import '../src/styles/bootstrap.css';
import 'font-awesome/css/font-awesome.min.css'; 

// automatically import all files ending in *.stories.js
const req = require.context('../src', true, /.story.jsx?$/);
function loadStories() {
  req.keys().forEach(filename => req(filename));
}

configure(loadStories, module);