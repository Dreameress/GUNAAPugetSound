import React, { Component, useState, useEffect } from 'react';
import { Route, Switch, Redirect, useLocation } from 'react-router-dom';

import { Layout } from './components/_shared/Layout';
import { Home } from './components/pages/Home/Home';
import { FetchData } from './components/_shared/FetchData';
import { Counter } from './components/_shared/Counter';
import { Contact } from './components/pages/ContactUs/Contact';
import { About } from './components/pages/About/About';
import { Membership } from './components/pages/Membership/Membership';
import { Scholarship } from './components/pages/Scholarship/Scholarship';
import { Officers } from './components/pages/Officers/Officers';
import { Committees } from './components/pages/Committees/Committees';
import { Calendar } from './components/pages/Calendar/Calendar';
import { Login } from './components/pages/Account/Login';
import { Register } from './components/pages/Authenticiation/Register';
import { PhotoAlbums } from './components/pages/Photos/PhotoAlbums';
import { AddAlbum } from './components/pages/Photos/AddAlbum';
import { EditAlbum } from './components/pages/Photos/EditAlbum';
import { AlbumDetails } from './components/pages/Photos/AlbumDetails';
import { AddPhoto } from './components/pages/Photos/AddPhoto';
import { ShowPhotos } from './components/pages/Photos/ShowPhotos';

import { Role } from './helpers/role';
import { accountService } from './services/account.service';
import { Alert } from './components/_shared/Alert';
import { Nav } from './components/_shared/Nav';
import { PrivateRoute } from './components/_shared/PrivateRoute';
import { Profile } from './components/pages/Profile/Profile';
import { Admin } from './components/pages/Admin/Admin';
import { Account } from './components/pages/Account/Account';

function App() {
  const { pathname } = useLocation();  
  const [user, setUser] = useState({});

  useEffect(() => {
      const subscription = accountService.user.subscribe(x => setUser(x));
      return subscription.unsubscribe;
  }, []);
    return (

      <Layout>
        <Nav />
        <Alert />
        <Switch>
          <Redirect from="/:url*(/+)" to={pathname.slice(0, -1)} />
          <Route exact path="/" component={Home} />
          <PrivateRoute path="/profile" component={Profile} />
          <PrivateRoute path="/admin" roles={[Role.Admin]} component={Admin} />
          <Route path="/account" component={Account} />
          <Route path='/counter' component={Counter} />
          <Route path='/fetchdata' component={FetchData} />
          <Route path='/scholarship' component={Scholarship} />
          <Route path='/membership' component={Membership} />
          <Route path='/about' component={About} />
          <Route path='/contact' component={Contact} />
          <Route path="/calendar" component={Calendar} />
          <Route path='/officers' component={Officers} />
          <Route path='/committees' component={Committees} />
          <Route path='/login' component={Login} />
          <Route path='/register' component={Register} />
          <Route path='/photoAlbums' component={PhotoAlbums} />
          <Route path='/addAlbum' component={AddAlbum} />
          <Route path='/editAlbum' component={EditAlbum} />
          <Route path='/albumDetails' component={AlbumDetails} />
          <Route path='/addPhoto' component={AddPhoto} />
          <Route path='/showPhotos' component={ShowPhotos} />
          <Redirect from="*" to="/" />
        </Switch>
      </Layout>
    );
  
  
}

export { App }; 
