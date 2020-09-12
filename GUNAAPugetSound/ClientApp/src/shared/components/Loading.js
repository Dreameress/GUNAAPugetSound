import React, { Component } from 'react';
import ReactDOM from "react-dom";

export class Loading extends Component {
  displayName = Loading.name

  constructor(props) {
    super(props);
    this.state = { loading: true };
  }
  
  render() {
    return (
        <div className="loading"><div>Loading...</div></div>
           
    );
  }
}
