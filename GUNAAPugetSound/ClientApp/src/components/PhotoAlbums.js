import React, { Component } from 'react';

export class PhotoAlbums extends Component {
  displayName = PhotoAlbums.name

  constructor(props) {
    super(props);
    this.state = { albums: [], loading: true };

    fetch('api/PhotoAlbum/GetAll')
      .then(response => response.json())
      .then(data => {
        this.setState({ albums: data, loading: false });
      });
  }
  }

  static renderAddAlbum() {
    return (
      <div class="authorized-options">
              <div class="auth-album-container">
                  <NavLink to="/CreateAlbum" class="btn btn-default btn-xs navbar-btn">Add Album<i class="fa fa-plus" aria-hidden="true"></i></NavLink>
              </div>
          </div>
    );
  }

  static renderPhotoAlbumSection(albums) {
    let albums = this.state.loading
    ? <p><em>Loading...</em></p>
    : FetchData.renderPhotoAlbumSection(this.state.albums);

    let EditAlbumDetails = this.state.autheticated
    ? <p><em></em></p>
    : FetchData.renderEditAlbumDetails();
    return (
      
      <div class="photoAlbumItem">
        
            {albums.map((album, index) =>
              <div >
                <NavLink to='/showAlbum' className="leader-panel"  key={index}> </NavLink>
                <h3>
                    <strong>{album.AlbumName}</strong>
                </h3>
                <p>{album.CreateTime}</p>
                </div>
                <div>
                {EditAlbumDetails}
                </div>
              
            )}
           
        </div>
    );
  }

  static render renderEditAlbumDetails(){
    return () (<div class="auth-album-detail-container">
              
    <NavLink to='/albumDetails' class="btn btn-default" >Details</a>
    <NavLink to='/editAlbum' class="btn btn-default" >Edit</a>
    <NavLink to='/deleteAlbum' class="btn btn-default" >Delete</a>
      
</div>);
  }
  

  render() {
    let contents = this.state.autheticated
      ? <p><em></em></p>
      : FetchData.renderAddAlbum();

      let albums = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderPhotoAlbumSection(this.state.albums);

     

    return (
      <div class="panel-heading text-center  golden-content">
      <h1>Photos</h1>
      <h4 class="red-header">Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more</h4>
  </div>
  <div class="panel-body  golden-content">
      <div class="albumsConainer">
       {albums}
      </div>

         {contents}
  
  </div>
       
      </div>
    );
  }
}
