import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';

export class MobileNavLink extends Component {
    displayName = MobileNavLink.name

    render() {
        let textLink, imageLink;
        if (this.props.page == "HOME") {
            textLink = <NavLink exact to={this.props.linkTo} className="visible-lg visible-md visible-sm" activeClassName='active' >{this.props.page}</NavLink>;
            imageLink = <NavLink exact to={this.props.linkTo} activeClassName='active' id="mIconHome" className="visible-xs mobileItem" >{this.props.page}<span className="sr-only">(current)</span></NavLink>;
        } else {
            textLink = <NavLink to={this.props.linkTo} className="visible-lg visible-md visible-sm">{this.props.page}</NavLink>;
            imageLink = <NavLink to={this.props.linkTo} id="mIconHome" className="visible-xs mobileItem" >{this.props.page}<span className="sr-only">(current)</span></NavLink>;

        }
        return (
            <div className="col-xs-4">
                {textLink}
                {imageLink}
            </div>
        );
    }
}