import React from 'react';


import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';

import ContainerHeader from './ContainerHeader';

storiesOf('Molecules', module)

.add('ContainerHeader with all content', () => (
    <ContainerHeader headerMessage="Welcome to the Home Site of the Puget Sound Chapter Of the Grambling University National Alumni Association"
    headerText="Welcome" /> 
))

.add('ContainerHeader with no Header Message', () => (
    <ContainerHeader
    headerText="Welcome" /> 
))