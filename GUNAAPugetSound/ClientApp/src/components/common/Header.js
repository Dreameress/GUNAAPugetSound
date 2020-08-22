import React, { Component } from 'react';
const hide = {
  display: 'none'
};

const show = {
  display: 'block'
};

export class Header extends Component {
  displayName = Header.name
  render() {   
    return (
    <div className="panel-heading text-center golden-content">
       <h1>{this.props.headerText} </h1>
       <h4 className="red-header" style={this.props.headerMessage == null ? hide : show}>{this.props.headerMessage}</h4>
     </div>
    );
  }
}