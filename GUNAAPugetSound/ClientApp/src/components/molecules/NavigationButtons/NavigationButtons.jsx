import React from 'react';

import WebNavLink from '../WebNavLink/WebNavLink';
import MobileNavLink from '../MobileNavLink/MobileNavLink'
require('./_style.scss');

export const PageList = 
[
    {page: "HOME", linkTo:"/"},
    {page: "CALENDAR", linkTo:"/calendar"},
    {page: "OFFICERS", linkTo:"/officers"},
    {page: "COMMITTEES", linkTo:"/committees"},
    {page: "MEMBERSHIP", linkTo:"/membership"},
    {page: "SCHOLARSHIP", linkTo:"/scholarship"},
    {page: "PHOTOS", linkTo:"/photoAlbums"},
    {page: "ABOUT", linkTo:"/about"},
    {page: "CONTACT", linkTo:"/contact"}
]

const NavigationButtons = ({pages = PageList, ...props}) => (
  <div id="navContainer">
    <ul className="nav navbar-nav active" id="centered-nav-web">
    {
      pages.map((page, i) => ( props.IsMobile ?<MobileNavLink page={page.page} linkTo={page.linkTo} key={i} />: <WebNavLink page={page.page} linkTo={page.linkTo} key={i} />))
    }
      {/* <WebNavLink page="HOME" linkTo="/" />
      <WebNavLink page="CALENDAR" linkTo="/calendar" />
      <WebNavLink page="OFFICERS" linkTo="/officers" />
      <WebNavLink page="COMMITTEES" linkTo="/committees" />
      <WebNavLink page="MEMBERSHIP" linkTo="/membership" />
      <WebNavLink page="SCHOLARSHIP" linkTo="/scholarship" />
      <WebNavLink page="PHOTOS" linkTo="/photoAlbums" />
      <WebNavLink page="ABOUT" linkTo="/about" />
      <WebNavLink page="CONTACT" linkTo="/contact" /> */}
    </ul>
  </div>
);

export default NavigationButtons;