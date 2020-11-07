import React from 'react';

import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';

import MainHeader from './MainHeader';
import SubHeader from './SubHeader';

storiesOf('Atoms', module)
// .add('Header with data', () => (
// <MainHeader>Welcome</MainHeader>
// ))

// storiesof('Atoms', module)
// .add('SubHeader with data', () => (
// <SubHeader>Welcome to the Home Site of the Puget Sound Chapter Of the Grambling University National Alumni Association</SubHeader>
// ))

.add('MainHeader', () => <MainHeader>Welcome</MainHeader>)

.add('SubHeader', () => <SubHeader>Welcome to the Home Site of the Puget Sound Chapter Of the Grambling University National Alumni Association</SubHeader>)