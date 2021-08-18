import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';

export class MobileNavLink extends Component {
    displayName = MobileNavLink.name

    render() {
        let textLink, imageLink;
        if (this.props.page == "HOME") {
            textLink = <NavLink exact to={this.props.linkTo} className="visible-xs mobileItem" activeClassName='active' >{this.props.page}<span className="sr-only">(current)</span></NavLink>;
            imageLink = <NavLink exact to={this.props.linkTo} activeClassName='active'><img src={this.props.src} width="60" height="60"  className="visible-xs mobileItem" alt="" /></NavLink>;
        } else {
            textLink = <NavLink to={this.props.linkTo} className="visible-xs mobileItem">{this.props.page}</NavLink>;
            imageLink = <NavLink to={this.props.linkTo}><img src={this.props.src} width="60" height="60"  className="visible-xs mobileItem" alt="" /></NavLink>;
        }
        return (
            <div className="col-xs-4">
                {imageLink}
                {textLink}
            </div>
        );
    }
}