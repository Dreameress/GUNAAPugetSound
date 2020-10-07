import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';

export class GeneralNavLink extends Component {
    displayName = GeneralNavLink.name
    
    render() {
        let navLink;
        if (this.props.page == "HOME") {
            navLink =  <NavLink exact to={this.props.linkTo} className="visible-lg visible-md visible-sm" activeClassName='active' >{this.props.page}</NavLink> 
        } else {
            navLink =  <NavLink to={this.props.linkTo} className="visible-lg visible-md visible-sm"  >{this.props.page}</NavLink>
        }
        return (
            <li>
              {navLink}
            </li>
        );
    }
}