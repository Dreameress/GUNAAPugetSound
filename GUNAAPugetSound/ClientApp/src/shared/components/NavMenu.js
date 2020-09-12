import React, { Component } from 'react';
import {NavLink, Link } from 'react-router-dom';
import AuthService from '../services/AuthService';
const img = '../dist/wwwroot/content/images/gunaasprites.png';


var navBackground = {
    backgroundImage: 'url(' + img + ')',
    backgroundRepeat: 'no-repeat'
};

var loginStyle = {
    margin: '0 auto',
    maxWidth: '830px'
};

var navMenuClass = null;
var navHeaderClass = null; 

var openMobileMenu = "openMobileMenu visible-xs";
var closedMobileMenu = "closedMobileMenu";
var openMobileHeader = "openMobileHeader navbar navbar-default";
var closedMobileHeader = "closedMobileHeader navbar navbar-default";

export class NavMenu extends Component {
  displayName = NavMenu.name
  constructor(props) {
    super(props);
    this.state = { initial: 'state', authenticated: null, toggled: false  };
    this.Auth = new AuthService();
    this.checkAuthentication = this.checkAuthentication.bind(this);
    this.logout = this.logout.bind(this);
    this.toggleMobileNavMenu = this.toggleMobileNavMenu.bind(this);
  }

   checkAuthentication() {
    //if (this.state.authenticated === null) return null;
      const loggedIn = this.Auth.loggedIn();
      if (loggedIn !== this.state.authenticated) {
        this.setState({ authenticated: loggedIn});
      }
   }

   toggleMobileNavMenu()
   {
       if(this.state.toggled)
       { this.setState({toggled : false})}
       else
       { this.setState({toggled : true})}
        navMenuClass = this.state.toggled ? openMobileMenu : closedMobileMenu;
        navHeaderClass = this.state.toggled ? openMobileHeader : closedMobileHeader;
      
     
   }
   componentWillMount(){
    this.checkAuthentication();
   }

   componentDidUpdate() {
    this.checkAuthentication();
    //this.checkToggle();
  }

  render() {
    if (this.state.authenticated === null) return null;
    navMenuClass = this.state.toggled ? openMobileMenu : closedMobileMenu;
    navHeaderClass = this.state.toggled ? openMobileHeader : closedMobileHeader;
    var loginButton;
    if(this.state.authenticated) {
      loginButton = this.renderLoggedIn();
     } else {
      loginButton = this.renderLoggedOut();
     }
    return (
      <nav id="navHeader" className={navHeaderClass}>
      <div className="container-fluid">
      <div>
          <NavLink to="/">
              <img className="visible-lg visible-md" id="headerWeb" style={navBackground} src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif" alt="gunaa sprite" />
              <img className="visible-sm" id="headerTablet" style={navBackground} src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif" alt="" />
              <img className="visible-xs" id="headerMobile" style={navBackground} src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif" alt="" />
          </NavLink>
      </div>
      <div id="navContainer">
          <ul className="nav navbar-nav active" id="centered-nav-web">
              <li className="active">
                  <NavLink exact to={'/'} activeClassName='active' className="visible-lg visible-md visible-sm" >HOME</NavLink>
              </li>
              <li>
                  <NavLink to={'/calendar'} className="visible-lg visible-md visible-sm">CALENDAR</NavLink>
              </li>
              <li>
                  <NavLink to={'/officers'} className="visible-lg visible-md visible-sm">OFFICERS</NavLink>
              </li>
              <li>
                  <NavLink to={'/committees'} className="visible-lg visible-md visible-sm">COMMITTEES</NavLink>
              </li>
              <li>
                  <NavLink to={'/membership'} className="visible-lg visible-md visible-sm">MEMBERSHIP</NavLink>
              </li>
              <li>
                  <NavLink to={'/scholarship'} className="visible-lg visible-md visible-sm">SCHOLARSHIP</NavLink>
              </li>
              <li>
                  <NavLink to={'/photoAlbums'} className="visible-lg visible-md visible-sm">PHOTOS</NavLink>
              </li>
              <li>
                  <NavLink to={'/about'} className="visible-lg visible-md visible-sm" >ABOUT</NavLink>
              </li>
              <li>
                  <NavLink to={'/contact'} className="visible-lg visible-md visible-sm">CONTACT</NavLink>
              </li>
          </ul>
      </div>
      <div id="logoContainer">
          <img id="headerTigerLogoWeb" src="../dist/wwwroot/content/images/Tiger.jpg" alt="" />
      </div>
      <div style={loginStyle} className="row">
      {loginButton}
     </div>
  </div>

  <div id="mobile-nav" className="visible-xs">
      <a id="mobileMenuButton"  onClick={this.toggleMobileNavMenu}><span></span></a>
      <div id="navMobileContainer" className={navMenuClass}  >
          <div id="mobileMenuDiv" className="visible-xs">
              <div className="row">
                  <div className="col-xs-4">
                      <NavLink exact to={'/'} activeClassName='active' ><img src="../dist/wwwroot/content/images/home3.svg" width="50" height="50" className="visible-xs" alt="" /></NavLink>
                      <NavLink exact to={'/'} activeClassName='active' id="mIconHome" className="visible-xs mobileItem" >HOME<span className="sr-only">(current)</span></NavLink>
                  </div>
                  <div className="col-xs-4">
                      <NavLink to={'/officers'}><img src="../dist/wwwroot/content/images/star-full.svg" width="50" height="50" /></NavLink>
                      <NavLink to={'/officers'} id="mIconOfficers" className="visible-xs mobileItem" >OFFICERS</NavLink>
                  </div>
                  <div className="col-xs-4">
                      <NavLink to={'/committees'}><img asp-controller="Home" asp-action="Committees" src="../dist/wwwroot/content/images/tree.svg" width="50" height="50" /></NavLink>
                      <NavLink to={'/committees'} id="mIconCommittees" className="visible-xs mobileItem" >COMMITTEES</NavLink>
                  </div>
              </div>
              <div className="row">
                  <div className="col-xs-4">
                      <NavLink to={'/about'}><img src="../dist/wwwroot/content/images/bubble.svg" width="50" height="50" /></NavLink>
                      <NavLink to={'/about'} id="mIconAbout" className="visible-xs mobileItem" asp-controller="Home" asp-action="About">ABOUT</NavLink>
                  </div>
                  <div className="col-xs-4">
                      <NavLink to={'/membership'}><img src="../dist/wwwroot/content/images/key.svg" width="50" height="50" /></NavLink>
                      <NavLink to={'/membership'} id="mIconMembership" className="visible-xs mobileItem" >MEMBERSHIP</NavLink>
                  </div>
                  <div className="col-xs-4">
                      <NavLink to={'/scholarship'}><img src="../dist/wwwroot/content/images/pencil.svg" width="50" height="50" /></NavLink>
                      <NavLink to={'/scholarship'} id="mIconScholarship" className="visible-xs mobileItem" >SCHOLARSHIP</NavLink>
                  </div>
              </div>
              <div className="row">
                  <div className="col-xs-4">
                      <NavLink to={'/calendar'}><img src="../dist/wwwroot/content/images/calendar.svg" width="50" height="50" /></NavLink>
                      <NavLink to={'/calendar'} id="mIconCal" className="visible-xs mobileItem" >CALENDAR</NavLink>
                  </div>
                  <div className="col-xs-4">
                      <NavLink to={'/photoAlbums'}><img src="../dist/wwwroot/content/images/camera.svg" width="50" height="50" /></NavLink>
                      <NavLink to={'/photoAlbums'} id="mIconPhotos" className="visible-xs mobileItem" >PHOTOS</NavLink>
                  </div>
                  <div className="col-xs-4">
                      <NavLink to={'/contact'}><img src="../dist/wwwroot/content/images/envelop.svg" width="50" height="50" /></NavLink>
                      <NavLink to={'/contact'} id="mIconContact" className="visible-xs mobileItem">CONTACT</NavLink>
                  </div>
              </div>
          </div>
      </div>
  </div>
</nav>
    );
    
  }

  logout()
  {
    this.Auth.logout();
    this.setState({ authenticated: false });
    //this.props.history.push('/');
   
   
  }

  renderLoggedIn() {
      return (<div className="navbar-form">
        <div className="loggedIn" >
          <NavLink to={'/profile'} className="manage-user">Profile</NavLink>
          <input value="Log Out" type="submit" onClick={this.logout} className="btn-danger" id="logout" />
        </div>
      </div>);
    }

 renderLoggedOut() {
    return( <div className="navbar-form">
      <div className="login" >
        <NavLink to={'/login'} className="btn btn-default btn-xs navbar-btn">Login</NavLink>
            <NavLink to={'/register'} className="btn btn-default btn-xs navbar-btn">Register</NavLink>
        </div>
    </div>);
  }
};
