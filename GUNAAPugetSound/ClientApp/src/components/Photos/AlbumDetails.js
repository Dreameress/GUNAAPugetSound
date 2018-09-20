import React, { Component } from 'react';
import decode from 'jwt-decode';
import AuthService from '../../services/AuthService';
import PhotoService from '../../services/PhotoService';
import {NavLink, Link, Redirect } from 'react-router-dom';

export class AlbumDetails extends Component {
  displayName = AlbumDetails.name
  constructor(props) {
    super(props);
    this.state = { albumName: '', albumDesc: '', authenticated: null, loading: true };
    this.Auth = new AuthService();
    this.PhotoServ = new PhotoService();
    this.checkAuthentication = this.checkAuthentication.bind(this);
    //this.checkAuthentication();
    var id = this.PhotoServ.getPhotoAlbumId();
    const Guid = 
    {
    Id: id
    }
    this.PhotoServ.getAlbumById(Guid).then(data => {
      this.setState({ albumName: data.albumName, albumDesc: data.albumDesc, createTime: data.createTime, editTime: data.editTime,  loading: false });
    });;
    
  }

  async checkAuthentication() {
    const authenticated = this.Auth.loggedIn();
      if (authenticated !== this.state.authenticated) {
        this.state.authenticated = authenticated;
      }
  }

  componentDidUpdate() {
    this.checkAuthentication();
  }

  render() {
    return  (
     
      <div className="panel-heading text-center">
         <h1>Album Details</h1>
        <div className="panel-body edit-album text-center" >
        <h3>{this.state.albumName}</h3>

          <div>Date Created: {this.state.createTime} | Last Edit: {this.state.editTime}</div>
          <div>Description:  {this.state.albumDesc}</div>
          <div class="authorized-options">
            <div class="unauth-photo-container">
              <NavLink to='/photoAlbums' class="btn btn-default btn-xs navbar-btn">Back to Photo Albums<i class="fa fa-camera" aria-hidden="true"></i></NavLink>
            </div>
          </div>
        </div>
      </div>
    );

  }

  handleChange(e) {
    this.setState(
      {
        [e.target.name]: e.target.value
      }
    )
  }
};