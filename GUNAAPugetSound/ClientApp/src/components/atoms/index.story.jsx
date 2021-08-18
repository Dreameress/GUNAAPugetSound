import React from 'react';

import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';

import MainHeader from './MainHeader/MainHeader';
import SubHeader from './SubHeader/SubHeader';
import HeaderImage, { Device } from './HeaderImage/HeaderImage';
import Icon from './Icon';
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

.add('Navigation Background for Mobile', () => <HeaderImage MOBILE ></HeaderImage>)

.add('Navigation Background for Tablet ', () => <HeaderImage TABLET ></HeaderImage>)

.add('Navigation Background for Web', () => <HeaderImage WEB></HeaderImage>)

.add('Navigation Background for Web (Default)', () => <HeaderImage ></HeaderImage>)

.add('Icon Email', () => <Icon email />)
.add('Icon Twitter', () => <Icon twitter />)
.add('Icon Facebook', () => <Icon facebook />)
.add('Icon Instagram', () => <Icon instagram />)
.add('Icon Donate', () => <Icon donate />)