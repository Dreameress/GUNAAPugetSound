import React, { Component } from 'react';

export class FetchData extends Component {
  displayName = FetchData.name

  constructor(props) {
    super(props);
    this.state = { albums: [], loading: true };

    fetch('api/PhotoAlbum/GetAll')
      .then(response => response.json())
      .then(data => {
        this.setState({ albums: data, loading: false });
      });
  }
  

  render() {
   

    return (
      <div class="panel-heading text-center  golden-content">
      <h1>Photos</h1>
      <h4 class="red-header">Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more</h4>
  
  <div class="panel-body  golden-content">
      <div class="albumsConainer">
      </div>

  
  </div>
  </div>
    );
  }
}
