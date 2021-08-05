import React from 'react';

const tigerImg ='../dist/wwwroot/content/images/Tiger.jpg'

const TigerLogoImage = ({ children, ...props }) => (
  <img id={props.headerTigerLogo} src={tigerImg} alt="" />
);

export default TigerLogoImage;