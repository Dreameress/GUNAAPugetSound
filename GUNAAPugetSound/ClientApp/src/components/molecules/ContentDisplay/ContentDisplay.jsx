import React from 'react';

const ContentDisplay = ({children, ...props}) =>
    (
        <div>
            <ContainerHeader headerText={props.Text} headerMessage={props.Message} />
            <div className="panel-body text-center golden-content">
                {children}
            </div>
        </div>

    );

    export default ContentDisplay;