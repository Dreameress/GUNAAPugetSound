import React, { Component } from 'react';
import ReactDOM from "react-dom";
import { FlapperSpinner } from "react-spinners-kit";

export class Loading extends Component {
  displayName = Loading.name

  constructor(props) {
    super(props);
    this.state = { loading: true };
  }
  
  render() {
    return (
        <div className="loading"><div>Loading...</div><FlapperSpinner
        size={30}
        color="#d54133"
        loading={this.loading}></FlapperSpinner></div>
           
    );
  }
}
