import React from 'react';
import cn from 'classnames';

const Icon = ({ facebook, instagram, twitter }) => (
  <div
    className={cn('icon', {
      'fab fa-facebook': !!facebook,
      'fab fa-instagram': !!instagram,
      'fab fa-twitter': !!twitter
    })}
  />
);

export default Icon;
