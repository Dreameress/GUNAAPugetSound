import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './navigation/NavMenu';
import Icon from './../atoms/Icon';
import Footer from './../organisms/Footer';
export class Layout extends Component {
  displayName = Layout.name

  render() {
    return (
      <div>
        <NavMenu />
        <div className="container-fluid" id="body-container">
            <div className="body-panel" >
               <div className="panel panel-default golden-content">{this.props.children}</div>
            </div>
        </div>
        <Footer /> 
    </div>
    );
  }
}
