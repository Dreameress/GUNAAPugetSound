import React from 'react';
import { NavLink } from 'react-router-dom';

var navBackground = {
  backgroundImage: 'url(' + img + ')',
  backgroundRepeat: 'no-repeat'
};


require('./_style.scss');

const NavigationHeader = () => (
  <div>
    <NavLink to="/">
      <img className="visible-lg visible-md" id="headerWeb" style={navBackground} src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif" alt="gunaa sprite" />
      <img className="visible-sm" id="headerTablet" style={navBackground} src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif" alt="" />
      <img className="visible-xs" id="headerMobile" style={navBackground} src="https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif" alt="" />
    </NavLink>
  </div>
);

export default NavigationHeader;