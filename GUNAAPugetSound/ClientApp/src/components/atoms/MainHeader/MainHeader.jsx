import React from 'react';

const MainHeader = ({children, ...props}) => (
    <h1 {...props}>{children} </h1>
);

export default MainHeader; 