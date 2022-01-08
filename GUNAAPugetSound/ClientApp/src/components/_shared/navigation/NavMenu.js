import React, { Component } from "react";
import { NavLink, Link } from "react-router-dom";
import AuthService from "../../../services/AuthService";
import { GeneralNavLink } from "./GeneralNavLink";
import { MobileNavLink } from "./MobileNavLink";

const img = "../dist/wwwroot/content/images/gunaasprites.png";
const tigerImg = "../dist/wwwroot/content/images/Tiger.jpg";

var navBackground = {
    backgroundImage: "url(" + img + ")",
    backgroundRepeat: "no-repeat",
};

var loginStyle = {
    margin: "0 auto"
};

var navMenuClass = null;
var navHeaderClass = null;

var openMobileMenu = "openMobileMenu visible-xs";
var closedMobileMenu = "closedMobileMenu";
var openMobileHeader = "openMobileHeader navbar navbar-default";
var closedMobileHeader = "closedMobileHeader navbar navbar-default";

export class NavMenu extends Component {
    displayName = NavMenu.name;
    constructor(props) {
        super(props);
        this.state = { initial: "state", authenticated: null, toggled: false };
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
        if (this.state.toggled) {
            this.setState({ toggled: false });
        } else {
            this.setState({ toggled: true });
        }
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
                            <img
                                className="visible-lg visible-md"
                                id="headerWeb"
                                style={navBackground}
                                src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif"
                                alt="gunaa sprite"
                            />
                            <img
                                className="visible-sm"
                                id="headerTablet"
                                style={navBackground}
                                src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif"
                                alt=""
                            />
                            <img
                                className="visible-xs"
                                id="headerMobile"
                                style={navBackground}
                                src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif"
                                alt=""
                            />
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
                    <div style={loginStyle} className="row secondaryNav">
                        <div className="col-sm-12 col-md-4" />
                        <div id="logoContainer" className="col-sm-12 col-md-4">
                            <img id="headerTigerLogoWeb" src={tigerImg} alt="" />
                        </div>
                        <div className="col-sm-12 col-md-4">
                        {loginButton}
                        </div>
                    </div>
                </div>

                <div id="mobile-nav" className="visible-xs">
                    <a id="mobileMenuButton" onClick={this.toggleMobileNavMenu}>
                        <span></span>
                    </a>
                    <div id="navMobileContainer" className={navMenuClass}>
                        <div id="mobileMenuDiv" className="visible-xs">
                            <div className="row">
                                <MobileNavLink
                                    page="HOME"
                                    linkTo="/"
                                    src="../dist/wwwroot/content/images/home3.svg"
                                />
                                <MobileNavLink
                                    page="CALENDAR"
                                    linkTo="/calendar"
                                    src="../dist/wwwroot/content/images/star-full.svg"
                                />
                                <MobileNavLink
                                    page="OFFICERS"
                                    linkTo="/officers"
                                    src="../dist/wwwroot/content/images/tree.svg"
                                />
                            </div>
                            <div className="row">
                                <MobileNavLink
                                    page="COMMITTEES"
                                    linkTo="/committees"
                                    src="../dist/wwwroot/content/images/bubble.svg"
                                />
                                <MobileNavLink
                                    page="MEMBERSHIP"
                                    linkTo="/membership"
                                    src="../dist/wwwroot/content/images/key.svg"
                                />
                                <MobileNavLink
                                    page="SCHOLARSHIP"
                                    linkTo="/scholarship"
                                    img
                                    src="../dist/wwwroot/content/images/pencil.svg"
                                />
                            </div>
                            <div className="row">
                                <MobileNavLink
                                    page="PHOTOS"
                                    linkTo="/photoAlbums"
                                    src="../dist/wwwroot/content/images/calendar.svg"
                                />
                                <MobileNavLink
                                    page="ABOUT"
                                    linkTo="/about"
                                    src="../dist/wwwroot/content/images/camera.svg"
                                />
                                <MobileNavLink
                                    page="CONTACT"
                                    linkTo="/contact"
                                    src="../dist/wwwroot/content/images/envelop.svg"
                                />
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
        return (
            <div className="navbar-form">
                <div className="loggedIn">
                    <NavLink to={"/profile"} className="manage-user">
                        Profile
                    </NavLink>
                    <input
                        value="Log Out"
                        type="submit"
                        onClick={this.logout}
                        className="btn-danger"
                        id="logout"
                    />
                </div>
            </div>
        );
    }

    renderLoggedOut() {
        return (
                <div className="login" style={{float: 'right'}}>
                    <Link
                        to="login"
                        className="btn btn-default-gold top-right-nav-btn">
                        Login
                        {/* <Icon login style={{ fontSize: 10, marginLeft: 5 }} /> */}
                    </Link>
                    <Link
                        to="register"
                        className="btn btn-default-gold top-right-nav-btn">
                        Register
                        {/* <Icon register style={{ fontSize: 10, marginLeft: 5 }} /> */}
                    </Link>
                </div>
            
        );
    }
}
export default NavMenu;
