import React from 'react';
import NavigationLink from '../../atoms/NavigationLink/NavigationLink';

const WebNavLink = ({children, ...props}) => 
(
    <li>
        {props.page == "HOME" ?
            <NavigationLink exact to={props.linkTo} className="visible-lg visible-md visible-sm" activeClassName='active' >{props.page}</NavigationLink> 
      :
            <NavigationLink to={props.linkTo} className="visible-lg visible-md visible-sm">{this.props.page}</NavigationLink>
        }
    </li>

);

export default WebNavLink