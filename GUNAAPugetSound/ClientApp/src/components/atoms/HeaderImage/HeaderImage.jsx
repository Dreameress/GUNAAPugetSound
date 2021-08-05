import React from 'react';
import cn from 'classnames';

const img = '../dist/wwwroot/content/images/gunaasprites.png';

const HeaderImage = ({ WEB, TABLET, MOBILE, ...props }) => (
  <img className={cn('.a___headerImage', {
    'visible-xs':!! MOBILE,
    'visible-sm': !!TABLET,
    'visible-lg visible-md': !!WEB,
  })}

    src={img} alt="gunaa sprite"
  />
);

export default HeaderImage;