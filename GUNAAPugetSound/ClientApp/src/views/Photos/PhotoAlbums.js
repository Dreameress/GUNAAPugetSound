import React, { Component } from 'react';
import {NavLink, Link, Redirect } from 'react-router-dom';
import AuthService from '../../shared/services/AuthService';
import PhotoService from '../../shared/services/PhotoService';
import { Loading } from '../../shared/components/Loading';

export class PhotoAlbums extends Component {
  displayName = PhotoAlbums.name

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
        this.setState({ albums: data, loading: false });
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

  static renderAddAlbum() {
    return (
      <div className="authorized-options">
              <div className="auth-album-container">
                  <NavLink to={'/addAlbum'} className="btn btn-default btn-xs navbar-btn">Add Album<i className="fa fa-plus" aria-hidden="true"></i></NavLink>
              </div>
          </div>
    );
  }




  render() {

    var albumText = this.state.albums.length > 0 ? "You must be logged in to add photos." : "No photo albums have been added as of yet.";
    let contents = this.Auth.loggedIn()
      ? PhotoAlbums.renderAddAlbum()
      : <p><em> {albumText }</em></p>;
    let albums = this.state.albums;
    

    return (
    <div className="panel-heading text-center  golden-content">
      <h1>Photos</h1>
      <h4 className="red-header">Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more</h4>
        <div className="panel-body  golden-content">
          {this.state.loading ? <Loading /> :   
     <div className="albumsConainer">
        {albums.map((album, index) =>
        <div className="photoAlbumItem" key={index}>
        <div  >
          <NavLink  to={'/showPhotos'} className="leader-panel" >
            <h3>
            <strong>{album.albumName}</strong>
            </h3>
            <p>{album.createTime}</p>
          </NavLink>
        </div>

        {  this.Auth.loggedIn()  && this.state.albums.length > 0
?    <div className="auth-album-detail-container">
<a id={album.id}  onClick={this.albumDetails.bind(this)} className="btn btn-default" >Details</a>
<a id={album.id} className="btn btn-default" onClick={this.editAlbum.bind(this)} >Edit </a>
<a id={album.id} type="submit" onClick={this.deleteAlbum.bind(this)} className="btn btn-default">Delete</a>
</div>
:<p></p>}
       
          
    </div>
      
     )}
     </div>}
          {contents}
        </div>
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
    this.PhotoService.deleteAlbum(guid, this).then(res => {
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
