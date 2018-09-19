import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Contact } from './components/Contact';
import { About } from './components/About';
import { Membership } from './components/Membership';
import { Scholarship } from './components/Scholarship';
import { Officers } from './components/Officers';
import { Committees } from './components/Committees';
import { Calendar } from './components/Calendar';
import { Login } from './components/Login';
import { Register } from './components/Register';
import { PhotoAlbums } from './components/PhotoAlbums';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
          <Route exact path='/' exact={true} component={Home} />
          <Route path='/counter' component={Counter} />
          <Route path='/fetchdata' component={FetchData} />
          <Route path='/scholarship' component={Scholarship} />
          <Route path='/membership' component={Membership} />
          <Route path='/about' component={About} />
          <Route path='/contact' component={Contact} />
          <Route path='/calendar' component={Calendar} />
          <Route path='/officers' component={Officers} />
          <Route path='/committees' component={Committees} />
          <Route path='/login' component={Login} />
          <Route path='/register' component={Register} />
          <Route path='/photoAlbums' component={PhotoAlbums} />
      </Layout>
    );
  }
}
