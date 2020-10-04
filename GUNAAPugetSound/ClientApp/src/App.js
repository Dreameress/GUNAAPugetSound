import React, { Component, useState, useEffect } from 'react';
import { Route, Switch, Redirect, useLocation } from 'react-router-dom';

import { Layout } from './shared/components/Layout';
import { Home } from './views/Home/Home';
import { FetchData } from './shared/components/FetchData';
import { Counter } from './shared/components/Counter';
import { Contact } from './views/ContactUs/Contact';
import { About } from './views/About/About';
import { Membership } from './views/Membership/Membership';
import { Scholarship } from './views/Scholarship/Scholarship';
import { Officers } from './views/Officers/Officers';
import { Committees } from './views/Committees/Committees';
import { Calendar } from './views/Calendar/Calendar';
import { Login } from './views/Authenticiation/Login';
import { Register } from './views/Authenticiation/Register';
import { PhotoAlbums } from './views/Photos/PhotoAlbums';
import { AddAlbum } from './views/Photos/AddAlbum';
import { EditAlbum } from './views/Photos/EditAlbum';
import { AlbumDetails } from './views/Photos/AlbumDetails';
import { AddPhoto } from './views/Photos/AddPhoto';
import { ShowPhotos } from './views/Photos/ShowPhotos';

import { Role } from './_helpers/role';
import { accountService } from './_services/account.service';
import { Alert } from './_components/Alert';
import { Nav } from './_components/Nav';
import { PrivateRoute } from './_components/PrivateRoute';
import { Profile } from './profile/Profile';
import { Admin } from './admin/Admin';
import { Account } from './account/Account';

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
          <PrivateRoute exact path="/" component={Home} />
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
