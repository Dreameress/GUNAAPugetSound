import React, { Component } from 'react';
import Gallery from 'react-photo-gallery';
import {NavLink, Link, Redirect } from 'react-router-dom';
import AuthService from './../../../services/AuthService';
import PhotoService from './../../../services/PhotoService';

export class ShowPhotos extends Component {
  displayName = ShowPhotos.name

  constructor(props) {
    super(props);
    this.state = { photos: [], loading: true, authenticated: null };
    this.deleteAlbum = this.deleteAlbum.bind(this);
    this.editAlbum = this.editAlbum.bind(this);
    this.albumDetails = this.albumDetails.bind(this);
    this.checkAuthentication = this.checkAuthentication.bind(this);
    this.Auth = new AuthService();
    this.PhotoService = new PhotoService();
    //this.checkAuthentication();
    //this.PhotoService.getAll();
    var id = this.PhotoService.getPhotoAlbumId();
    const Guid = 
    {
    Id: id
    }
    this.PhotoService.getPhotosById(Guid).then(data => {
      this.setState({ photos: data, loading: false });
    });;

    // fetch('api/PhotoAlbum/GetAll')
    //   .then(response => response.json())
    //   .then(data => {
    //     this.setState({  });
    //   });
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
                  <NavLink to={'/photoAlbums'} className="btn btn-default btn-xs navbar-btn" style={{marginLeft: 5}}>Back to Photo Albums<i className="fa fa-camera" aria-hidden="true"></i></NavLink>
              </div>
      </div>
    );
  }

  static renderAuthorizedAddPhotos() {
    return (
      <div className="authorized-options">
      <div className="col-md-offset-1 col-md-10">
                  <NavLink to={'/addPhoto'} className="btn btn-default btn-xs navbar-btn">Add Photo(s)<i className="fa fa-plus" aria-hidden="true"></i></NavLink>
                  <NavLink to={'/photoAlbums'} className="btn btn-default btn-xs navbar-btn" style={{marginLeft: 5}}>Back to Photo Albums<i className="fa fa-camera" aria-hidden="true"></i></NavLink>
                </div>
              {/* <div className="auth-album-container">
                  <NavLink to={'/addPhotos'} className="btn btn-default btn-xs navbar-btn">Add Photo(s)<i className="fa fa-plus" aria-hidden="true"></i></NavLink>
                  <NavLink to={'/photoAlbums'} className="btn btn-default btn-xs navbar-btn" style={{padding: 7}}>Back to Photo Albums<i className="fa fa-camera" aria-hidden="true"></i></NavLink>
              </div> */}
      </div>
    );
  }


  render() {

    var photoText = this.state.photos.length == 0 ? "No photos have been added as of yet." : "Loading";
    photoText = this.Auth.loggedIn() ? photoText + " You must be logged in to add photos." : photoText;
    let contents = this.Auth.loggedIn()
      ? ShowPhotos.renderAddPhotos()
      : <p><em> {photoText }</em></p>;
    let albums = this.state.albums;
    var gallery =  this.state.photos.length > 0 ?  <Gallery photos={this.state.photos} /> : photoText;

    return (
    <div className="panel-heading text-center  golden-content">
      <h1>Photos</h1>
      <h4 className="red-header">Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more</h4>
        <div className="panel-body  golden-content">
          <div className="albumsContainer">
            {gallery}
          </div>
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
