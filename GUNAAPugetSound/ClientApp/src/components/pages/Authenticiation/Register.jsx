import React, { Component } from 'react';
import AuthService from './../../../services/AuthService';

export class Register extends Component {
  displayName = Register.name
  constructor(props) {
    super(props);
    this.state = { username: '', password: '', authenticated: false, loading: true };
    this.handleChange = this.handleChange.bind(this);
    this.handleFormSubmit = this.handleFormSubmit.bind(this);
    this.Auth = new AuthService();
  }
  componentWillMount(){
    if(this.Auth.loggedIn())
        this.props.history.replace('/');
    }

  render() {
    return (
      <div className="panel-heading text-center">
        <h1>Register</h1>
        <h4 class="red-header">Sign up for a GUNAA Puget Sound account</h4>
        <div className="panel-body">
     
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
                  <span className="text-danger field-validation-valid" ></span>
                </div>
              </div>
              <div className="form-group">
                <label className="col-md-2 control-label">Confirm Password</label>
                <div className="col-md-10">
                  <input name="confrimPassword"
                    type="password"
                    onChange={this.handleChange} className="form-control valid" id="ConfirmPassword" name="confirmPassword" type="password" />
                  <span className="text-danger field-validation-valid" ></span>
                </div>
              </div>
              <div className="form-group">
                <div className="col-md-offset-1 col-md-10">
                  <input onClick={this.handleFormSubmit} style={{ margin: 0 }} type="submit" value="Register" className="btn btn-default" />
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

    this.Auth.register(this.state.username, this.state.password).then(res =>
      {
        if(res.message !== null)
        {
          this.setState({ authenticated: true});
        }
          
      });;
  
    
  }
};