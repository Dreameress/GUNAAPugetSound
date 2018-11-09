import React, { Component } from 'react';
import decode from 'jwt-decode';
import AuthService from '../../services/AuthService';
import PhotoService from '../../services/PhotoService';
import {NavLink, Link, Redirect } from 'react-router-dom';

export class AddPhoto extends Component {
  displayName = AddPhoto.name
  constructor(props) {
    super(props);
    this.state = { photoDesc: '', files: [], authenticated: null, loading: true };
    this.handleChange = this.handleChange.bind(this);
    this.handleFormSubmit = this.handleFormSubmit.bind(this);
    this.Auth = new AuthService();
    this.PhotoServ = new PhotoService();
    this.checkAuthentication = this.checkAuthentication.bind(this);
    this.checkAuthentication();
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
    if (this.state.authenticated === null) return null;
    return this.state.authenticated === false ?
    <Redirect to={{ pathname: '/' }}/> : (
      <div className="panel-heading text-center">
         <h1>Upload Images</h1>
        <div className="panel-body edit-album text-center" >
    
            <form className="form-horizontal">
              <div className="form-group">
                <label className="control-label col-sm-3">Album Description</label>
                <div class="col-sm-5">
                  <input name="photoDesc"
                    type="text"
                    onChange={this.handleChange} className="form-control valid" id="photoDesc" type="text" />
                </div>
              </div>
              <div className="form-group">
                <label className="control-label col-sm-3">Album Description</label>
                <div class="col-sm-5">
                  <input name="files" multiple="multiple"
                    type="file" accept=".jpg, .png, .gif"
                    onChange={this.handleChange} className="form-control valid" id="photoDesc" />
                </div>
              </div>
              <div className="form-group">
              <div className="col-md-offset-1 col-md-10">
                  <input onClick={this.handleFormSubmit.bind(this)} style={{ margin: 0 }} type="submit" value="Save" className="btn btn-default" />
                  <NavLink to='/albumPhotos' class="btn btn-default btn-xs navbar-btn" style={{padding: 7}}>Back to Photo Albums<i class="fa fa-camera" aria-hidden="true"></i></NavLink>
                </div>
              </div>
            </form>
     
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

  handleFormSubmit(e) {
    e.preventDefault();
    var user = this.Auth.getUserId();
    const AppUser = 
    {
      username: user,
      password: ''
    }

    const PhotoModel = 
    {
      photoDesc: this.state.photoDesc,
      files: this.state.files
    }

     this.PhotoServ.addPhoto(AppUser, PhotoModel).then(res => {
       this.props.history.push('/albumPhotos');
    
  });
   
  }
};