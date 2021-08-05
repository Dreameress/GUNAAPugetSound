import React from 'react';

const SubHeader = ({children, ...props}) => (
    <h4 className="red-header" {...props}>{children}</h4>
);
export default SubHeader;