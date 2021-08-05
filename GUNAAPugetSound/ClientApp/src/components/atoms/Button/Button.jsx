import React from 'react';

require('./_style.scss');

const Button = ({ children, ...props }) => (
  <button {...props}>{children}</button>
);

export default Button;