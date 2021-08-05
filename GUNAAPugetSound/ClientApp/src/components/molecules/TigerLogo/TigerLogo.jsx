import React from 'react';

import TigerLogoImage from '../../atoms/TigerLogoImage/TigerLogoImage'

require('./_style.scss');

const TigerLogo = ({ children, ...props }) => (
  <div id="logoContainer">
    <TigerLogoImage headerTigerLogo={props.headerTigerLogo} />
  </div>
);

export default TigerLogo;