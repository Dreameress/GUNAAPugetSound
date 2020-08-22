import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './views/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Contact } from './views/Contact';
import { About } from './views/About';
import { Membership } from './views/Membership';
import { Scholarship } from './views/Scholarship';
import { Officers } from './views/Officers';
import { Committees } from './views/Committees';
import { Calendar } from './views/Calendar';
import { Login } from './views/Login';
import { Register } from './views/Register';
import { PhotoAlbums } from './views/PhotoAlbums';
import { AddAlbum } from './components/Photos/AddAlbum';
import { EditAlbum } from './components/Photos/EditAlbum';
import { AlbumDetails } from './components/Photos/AlbumDetails';
import { AddPhoto } from './components/Photos/AddPhoto';
import { ShowPhotos } from './components/Photos/ShowPhotos';

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
          <Route path='/addAlbum' component={AddAlbum} />
          <Route path='/editAlbum' component={EditAlbum} />
          <Route path='/albumDetails' component={AlbumDetails} />
          <Route path='/addPhoto' component={AddPhoto} />
          <Route path='/showPhotos' component={ShowPhotos} />
      </Layout>
    );
  }
}
