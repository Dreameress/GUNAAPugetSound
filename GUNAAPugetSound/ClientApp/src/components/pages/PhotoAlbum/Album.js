import React from 'react';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import Moment from 'react-moment';
import { Button } from 'react-bootstrap';

const redirectToAlbumDetails = (id, history) => {
    history.push('/albumDetails/' + id);
}
const redirectToUpdateAlbum = (id, history) => {
    history.push('/editAlbum/' + id);
}
const redirectToDeleteAlbum = (id, history) => {
    history.push('/deleteAlbum/' + id);
}
const album = (props) => {
    return (
        <Aux>
               <div className="photoAlbumItem" key={index}>
                  <div  >
                    <NavLink to={'/showPhotos'} className="leader-panel" >
                      <h3>
                        <strong>{album.albumName}</strong>
                      </h3>
                      <p>{album.createTime}</p>
                    </NavLink>
                  </div>

                  {this.state.albums.length > 0
                    ? <div className="auth-album-detail-container">
                      <a id={album.id} onClick={() => redirectToAlbumDetails(props.owner.id, props.history)} className="btn btn-default" >Details</a>
                      <a id={album.id} className="btn btn-default" onClick={() => redirectToUpdateAlbum(props.owner.id, props.history)} >Edit </a>
                      <a id={album.id} type="submit"  onClick={() => redirectToDeleteAlbum(props.owner.id, props.history)} className="btn btn-default">Delete</a>
                    </div>
                    : <p></p>}
                </div>
        </Aux>
    )
}
export default album;