import React from 'react';
import { NavLink } from 'react-router-dom';

const NavigationLink = ({ children, ...props }) => (
  <NavLink {...props}>{children}</NavLink>
);

export default NavigationLink;