import React, { Component } from 'react';
import AuthService from '../../shared/services/AuthService';
import {NavLink, Link, Redirect } from 'react-router-dom';

export class Login extends Component {
  displayName = Login.name
  constructor(props) {
    super(props);
    this.state = { username: '', password: '', authenticated: null, loading: true };
    this.handleChange = this.handleChange.bind(this);
    this.handleFormSubmit = this.handleFormSubmit.bind(this);
    this.Auth = new AuthService();
    this.checkAuthentication = this.checkAuthentication.bind(this);
    this.checkAuthentication();
  }

  async checkAuthentication() {
    const authenticated = this.Auth.loggedIn();
      if (authenticated !== this.state.authenticated) {
        this.setState({ authenticated: authenticated});
      }
  }

  componentDidUpdate() {
    this.checkAuthentication();
  }

  componentWillMount(){
    this.checkAuthentication();    
    }

  render() {
    //if (this.state.authenticated === null) return null;
    return (
      <div className="panel-heading text-center">
        <h1>Login</h1>
        <div className="panel-body">
          <section id="loginForm">
            <form className="form-horizontal">

              <div className="form-group">
                <label className="col-md-2 control-label" >Email</label>
                <div className="col-md-10">
                  <input name="username"
                    type="text"
                    onChange={this.handleChange} className="form-control valid" data-val="true" id="Email" name="username" />
                  <span className="text-danger field-validation-valid" data-valmsg-for="Email" data-valmsg-replace="true"></span>
                </div>
              </div>
              <div className="form-group">
                <label className="col-md-2 control-label">Password</label>
                <div className="col-md-10">
                  <input name="password"
                    type="password"
                    onChange={this.handleChange} className="form-control valid" id="Password" name="password" type="password" />
                  <span className="text-danger field-validation-valid" data-valmsg-for="Password" data-valmsg-replace="true"></span>
                </div>
              </div>
              <div className="form-group">
                <div className="col-md-offset-1 col-md-10">
                  <input onClick={this.handleFormSubmit} style={{ margin: 0 }} type="submit" value="Log in" className="btn btn-default" />
                </div>
              </div>
              <p>
                <a href="/register">Register as a new user</a>
              </p>
            </form>
          </section>
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

     this.Auth.login(this.state.username, this.state.password).then(res =>
        {
            this.setState({ authenticated: true});
            if(this.props.history != null){
              this.props.history.goBack();
            }
            else
            {
              <Redirect to='/' />
            }
            
        });
   
  }
};