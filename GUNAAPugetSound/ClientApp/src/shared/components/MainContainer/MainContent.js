import React, { Component } from 'react';

const hide = {
  display: 'none'
};

const show = {
  display: 'block'
};

export class MainContent extends Component {
  displayName = MainContent.name
  render() {
    return (
      <div className="panel-body text-center golden-content">
        <p>We would like to welcome all alumni and supporters living in and visiting the Seattle area. We welcome your support as we continue our mission of recruiting students to our alma mater. </p>
        <p>If you are in the Puget Sound area and interested in attending Grambling State University or currently attending Grambling State University, please reach out to us for information on the scholarships we provide.</p>
        <div className="text-center">
          <p>Go Tigers!!!</p>
          <h5><strong>Grambling, Where Everybody is Somebody</strong></h5>
        </div>
      </div>
    );
  }
}