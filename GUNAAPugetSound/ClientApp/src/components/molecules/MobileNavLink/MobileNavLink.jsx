import React from 'react';
import NavigationLink from '../../atoms/NavigationLink/NavigationLink';

const MobileNavLink = ({ children, ...props }) =>
    (
        <div className="col-xs-4">
            {props.page == "HOME" ?
                <NavigationLink exact to={props.linkTo} className="visible-lg visible-md visible-sm" activeClassName='active' >{props.page}</NavigationLink> &&
                <NavigationLink exact to={props.linkTo} activeClassName='active' id="mIconHome" className="visible-xs mobileItem" >{props.page}<span className="sr-only">(current)</span></NavigationLink>
                :
                <NavigationLink to={props.linkTo} className="visible-lg visible-md visible-sm">{props.page}</NavigationLink> &&
                <NavigationLink to={props.linkTo} id="mIconHome" className="visible-xs mobileItem" >{props.page}<span className="sr-only">(current)</span></NavigationLink>
            }
        </div>
    );
export default MobileNavLink;