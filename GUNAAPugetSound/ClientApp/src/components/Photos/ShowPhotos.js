import React, { Component } from 'react';
import Gallery from 'react-photo-gallery';
import {NavLink, Link, Redirect } from 'react-router-dom';
import AuthService from '../../services/AuthService';
import PhotoService from '../../services/PhotoService';

export class ShowPhotos extends Component {
  displayName = ShowPhotos.name

  constructor(props) {
    super(props);
    this.state = { albums: [], loading: true, authenticated: null };
    this.deleteAlbum = this.deleteAlbum.bind(this);
    this.editAlbum = this.editAlbum.bind(this);
    this.albumDetails = this.albumDetails.bind(this);
    this.checkAuthentication = this.checkAuthentication.bind(this);
    this.Auth = new AuthService();
    this.PhotoService = new PhotoService();
    //this.checkAuthentication();
    //this.PhotoService.getAll();

    fetch('api/PhotoAlbum/GetAll')
      .then(response => response.json())
      .then(data => {
        this.setState({ photos: data, loading: false });
      });
  }

  async checkAuthentication() {
    //if (this.state.authenticated === null) return null;
    const loggedIn = this.Auth.loggedIn();
    if (loggedIn !== this.state.authenticated) {
      this.setState({ authenticated: loggedIn});
    }
  }
  componentWillMount(){
    this.checkAuthentication();
   }

  componentDidUpdate() {
    this.checkAuthentication();
  }

  static renderAddPhotos() {
    return (
      <div className="authorized-options">
              <div className="auth-album-container">
                  <NavLink to={'/photoAlbums'} class="btn btn-default btn-xs navbar-btn" style={{padding: 7}}>Back to Photo Albums<i class="fa fa-camera" aria-hidden="true"></i></NavLink>
              </div>
      </div>
    );
  }

  static renderAuthorizedAddPhotos() {
    return (
      <div className="authorized-options">
              <div className="auth-album-container">
                  <NavLink to={'/addPhotos'} className="btn btn-default btn-xs navbar-btn">Add Photo(s)<i className="fa fa-plus" aria-hidden="true"></i></NavLink>
                  <NavLink to={'/photoAlbums'} class="btn btn-default btn-xs navbar-btn" style={{padding: 7}}>Back to Photo Albums<i class="fa fa-camera" aria-hidden="true"></i></NavLink>
              </div>
      </div>
    );
  }


  render() {

    var photoText = this.state.photos.length > 0 ? "You must be logged in to add photos." : "No photo albums have been added as of yet.";
    let contents = this.Auth.loggedIn()
      ? ShowPhotos.renderAddPhotos()
      : <p><em> {photoText }</em></p>;
    let albums = this.state.albums;

    return (
    <div className="panel-heading text-center  golden-content">
      <h1>Photos</h1>
      <h4 className="red-header">Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more</h4>
        <div className="panel-body  golden-content">
          <div className="albumsConainer">
          <Gallery photos={this.state.photos} />
          </div>
          {photoText}
        </div>
      {this.Auth.loggedIn()
      ? ShowPhotos.renderAuthorizedAddPhotos()
      : ShowPhotos.renderAddPhotos()}
    </div>
    );
  }

  albumDetails(e) {
    e.preventDefault();// make a separate copy of the array
    var index = e.target.id;
    this.PhotoService.setPhotoAlbumId(index);
    this.props.history.push('/albumDetails');
  }

  editAlbum(e) {
    e.preventDefault();// make a separate copy of the array
    var index = e.target.id;
    this.PhotoService.setPhotoAlbumId(index);
    this.props.history.push('/editAlbum');
  }

  deleteAlbum(e) {
    e.preventDefault();// make a separate copy of the array
    var index = e.target.id;
    const guid = 
    {
        Id: index
    }
    var self = this;
    this.PhotoService.delete(guid, this).then(res => {
      self.setState({ loading: true });
      fetch('api/PhotoAlbum/GetAll')
      .then(response => response.json())
      .then(data => {
        this.setState({ albums: data, loading: false, authenticated: true });
        //self.props.history.push('/photoAlbums');
      });
     

    });
  }
}
