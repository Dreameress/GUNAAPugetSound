import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div>
        <div className="panel-heading text-center golden-content">
            <h1>Welcome </h1>
            <h4 className="red-header">Welcome to the Home Site of the Puget Sound Chapter Of the Grambling University National Alumni Association</h4>
            <div className="panel-body golden-content">
                <p>We would like to welcome all alumni and supporters living in and visiting the Seattle area. We welcome your support as we continue our mission of recruiting students to our alma mater. </p>
                <p>If you are in the Puget Sound area and interested in attending Grambling State University or currently attending Grambling State University, please reach out to us for information on the scholarships we provide.</p>
                <div className="text-center">
                    <p>Go Tigers!!!</p>
                    <h5><strong>Grambling, Where Everybody is Somebody</strong></h5>
                </div>
            </div>
        </div>
        </div>
    );
  }
}
