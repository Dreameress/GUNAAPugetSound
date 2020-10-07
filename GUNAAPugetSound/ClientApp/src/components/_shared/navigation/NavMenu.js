import React, { Component } from 'react';
import { NavLink, Link } from 'react-router-dom';
import AuthService from '../../../services/AuthService';
import { GeneralNavLink } from './GeneralNavLink';
import { MobileNavLink } from './MobileNavLink';
const img = '../dist/wwwroot/content/images/gunaasprites.png';
const tigerImg ='../dist/wwwroot/content/images/Tiger.jpg'

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
        this.state = { initial: 'state', authenticated: null, toggled: false };
        this.Auth = new AuthService();
        this.checkAuthentication = this.checkAuthentication.bind(this);
        this.logout = this.logout.bind(this);
        this.toggleMobileNavMenu = this.toggleMobileNavMenu.bind(this);
    }

    checkAuthentication() {
        //if (this.state.authenticated === null) return null;
        const loggedIn = this.Auth.loggedIn();
        if (loggedIn !== this.state.authenticated) {
            this.setState({ authenticated: loggedIn });
        }
    }

    toggleMobileNavMenu() {
        if (this.state.toggled) { this.setState({ toggled: false }) }
        else { this.setState({ toggled: true }) }
        navMenuClass = this.state.toggled ? openMobileMenu : closedMobileMenu;
        navHeaderClass = this.state.toggled ? openMobileHeader : closedMobileHeader;


    }
    componentWillMount() {
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
        if (this.state.authenticated) {
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
                            <GeneralNavLink page="HOME" linkTo="/" />
                            <GeneralNavLink page="CALENDAR" linkTo="/calendar" />
                            <GeneralNavLink page="OFFICERS" linkTo="/officers" />
                            <GeneralNavLink page="COMMITTEES" linkTo="/committees" />
                            <GeneralNavLink page="MEMBERSHIP" linkTo="/membership" />
                            <GeneralNavLink page="SCHOLARSHIP" linkTo="/scholarship" />
                            <GeneralNavLink page="PHOTOS" linkTo="/photoAlbums" />
                            <GeneralNavLink page="ABOUT" linkTo="/about" />
                            <GeneralNavLink page="CONTACT" linkTo="/contact" />
                        </ul>
                    </div>
                    <div id="logoContainer">
                        <img id="headerTigerLogoWeb" src={tigerImg} alt="" />
                    </div>
                    <div style={loginStyle} className="row">
                        {loginButton}
                    </div>
                </div>

                <div id="mobile-nav" className="visible-xs">
                    <a id="mobileMenuButton" onClick={this.toggleMobileNavMenu}><span></span></a>
                    <div id="navMobileContainer" className={navMenuClass}  >
                        <div id="mobileMenuDiv" className="visible-xs">
                            <div className="row">
                                <MobileNavLink page="HOME" linkTo="/" />
                                <MobileNavLink page="CALENDAR" linkTo="/calendar" />
                                <MobileNavLink page="OFFICERS" linkTo="/officers" />
                            </div>
                            <div className="row">
                                <MobileNavLink page="COMMITTEES" linkTo="/committees" />
                                <MobileNavLink page="MEMBERSHIP" linkTo="/membership" />
                                <MobileNavLink page="SCHOLARSHIP" linkTo="/scholarship" />
                            </div>
                            <div className="row">
                                <MobileNavLink page="PHOTOS" linkTo="/photoAlbums" />
                                <MobileNavLink page="ABOUT" linkTo="/about" />
                                <MobileNavLink page="CONTACT" linkTo="/contact" />
                            </div>
                        </div>
                    </div>
                </div>
            </nav>
        );

    }

    logout() {
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
        return (<div className="navbar-form">
            <div className="login" >
                
            <Link to="login" className="btn btn-default btn-xs navbar-btn">Login</Link>
            <Link to="register" className="btn btn-default btn-xs navbar-btn">Register</Link>
            </div>
        </div>);
    }
};
