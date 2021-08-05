import React, { Component } from 'react';
import AuthService from '../../../services/AuthService';
import PhotoService from '../../../services/PhotoService';
import { NavLink, Link, Redirect } from 'react-router-dom';

export class AddAlbum extends Component {
  displayName = AddAlbum.name
  constructor(props) {
    super(props);
    this.state = { albumName: '', albumDesc: '', authenticated: null, loading: false };
    // this.handleChange = this.handleChange.bind(this);
    // this.handleFormSubmit = this.handleFormSubmit.bind(this);
    // this.Auth = new AuthService();
    // this.PhotoServ = new PhotoService();
    // this.checkAuthentication = this.checkAuthentication.bind(this);
    // this.checkAuthentication();
  }

  // async checkAuthentication() {
  //   const authenticated = this.Auth.loggedIn();
  //     if (authenticated !== this.state.authenticated) {
  //       this.state.authenticated = authenticated;
  //     }
  // }

  // componentDidUpdate() {
  //   this.checkAuthentication();
  // }

  render() {
    // if (this.state.authenticated === null) return null;
    // return this.state.authenticated === false ?
    // <Redirect to={{ pathname: '/' }}/> : (
    return (
      <div className="panel-heading text-center">
        <h1>Create Album</h1>
        <div className="panel-body edit-album text-center" >

          <form className="form-horizontal">

            <div className="form-group">
              <label className="col-md-2 control-label" >Album Name:</label>
              <div className="col-md-10">
                <input name="albumName"
                  type="text"
                  className="form-control valid" />
              </div>
            </div>
            <div className="form-group">
              <label className="col-md-2 control-label">Album Description</label>
              <div className="col-md-10">
                <input name="albumDesc"
                  type="text"
                  className="form-control valid" id="AlbumDesc" type="text" />
              </div>
            </div>
            <div className="form-group">
              <div className="col-md-offset-1 col-md-10">
                <input style={{ margin: 0 }} type="submit" value="Save" className="btn btn-default" />
                <NavLink to='/photoAlbums' className="btn btn-default btn-xs navbar-btn" style={{ padding: 7 }}>Back to Photo Albums<i className="fa fa-camera" aria-hidden="true"></i></NavLink>
              </div>
            </div>
          </form>

        </div>
      </div>
    );

  }

  // // handleChange(e) {
  // //   this.setState(
  // //     {
  // //       [e.target.name]: e.target.value
  // //     }
  // //   )
  // // }

  // handleFormSubmit(e) {
  //   e.preventDefault();
  //   //var userId = this.Auth.getProfile();
  //   var user = this.Auth.getUserId();
  //   const AppUser =
  //   {
  //     username: user,
  //     password: ''
  //   }

  //   const AlbumModel =
  //   {
  //     albumDesc: this.state.albumDesc,
  //     albumName: this.state.albumName
  //   }

  //   // this.PhotoServ.addAlbum(AppUser, AlbumModel).then(res => {
  //   //   this.props.history.push('/photoAlbums');

  //   // });

  // }
};