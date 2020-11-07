import React from 'react';

import MainHeader from '../atoms/MainHeader';
import SubHeader from '../atoms/SubHeader';

const ContainerHeader = ({headerMessage = '', headerText = '', ...props}) => 
(
    <div className="panel-heading text-center golden-content">
        <MainHeader>{headerText}</MainHeader>
        {headerMessage !== null && headerMessage !== '' &&
        <SubHeader className="red-header">{headerMessage}</SubHeader> 
        }
    </div>
);
export default ContainerHeader;