import React from 'react';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import Moment from 'react-moment';
import { Button } from 'react-bootstrap';
import { Link, NavLink } from 'react-router-dom';

const redirectToPhotoAlbumDetails = (id, history) => {
    history.push('/photoAlbumDetails/' + id);
}
const redirectToUpdatePhotoAlbum = (id, history) => {
    history.push('/updatePhotoAlbum/' + id);
}
const redirectToDeletePhotoAlbum = (id, history) => {
    history.push('/deletePhotoAlbum/' + id);
}

const photoAlbum = (props, index) => {
    return (
        <Aux>
            <div className="albumsContainer">
                <div className="photoAlbumItem" key={index}>
                    <div  >
                        <NavLink to={'/showPhotos'} className="leader-panel" >
                            <h3>
                                <strong>{props.album.albumName}</strong>
                            </h3>
                            <p>{props.album.createTime}</p>
                        </NavLink>
                    </div>
                    <div className="auth-album-detail-container">
                        <a id={props.album.id} onClick={() => redirectToPhotoAlbumDetails(props.album.id, props.history)} className="btn btn-default" >Details</a>
                        <a id={props.album.id} className="btn btn-default" onClick={() => redirectToUpdatePhotoAlbum(props.album.id, props.history)} >Edit </a>
                        <a id={props.album.id} type="submit" onClick={() => redirectToDeletePhotoAlbum(props.album.id, props.history)} className="btn btn-default">Delete</a>
                    </div>
                </div>
            </div>
        </Aux>
    )
}
export default photoAlbum;