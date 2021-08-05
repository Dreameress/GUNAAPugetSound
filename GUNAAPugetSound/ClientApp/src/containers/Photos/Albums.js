import React, { Component } from 'react';
import { Table, Col, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import { connect } from 'react-redux';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import Album from '../../components/pages/Photos/Album';

componentDidMount = () => {
    let url = '/api/PhotoAlbums';
    this.props.onGetData(url, { ...this.props });
}
const renderAddAlbum = (props) => {
    return (
        <div className="authorized-options">
            <div className="auth-album-container">
                <NavLink to={'/addAlbum'} className="btn btn-default btn-xs navbar-btn">Add Album<i className="fa fa-plus" aria-hidden="true"></i></NavLink>
            </div>
        </div>
    );
}

class Albums extends Component {
    render() {
        let albums = [];
        let albumText = 'No photo albums have been added as of yet.';
        let contents; 
        if (this.props.data && this.props.data.length > 0) {
            albums = this.props.data.map((album) => {
                return (
                    <Album key={album.id} album={album} {...this.props} />
                )
            });
            contents = albums.length > 0 ? renderAddAlbum() : <p><em> {albumText}</em></p>;
        }

        // = this.state.albums.length > 0 ? "You must be logged in to add photos." : 


        return (
            <Aux>
                <div className="panel-heading text-center  golden-content">
                    <h1>Photos</h1>
                    <h4 className="red-header">Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more</h4>
                    <div className="panel-body  golden-content">
                        {this.state.loading ? <Loading /> :
                            <div className="albumsContainer">
                                {albums.map((album, index) =>
                                    <div className="photoAlbumItem" key={index}>
                                        <div  >
                                            <NavLink to={'/showPhotos'} className="leader-panel" >
                                                <h3>
                                                    <strong>{album.albumName}</strong>
                                                </h3>
                                                <p>{album.createTime}</p>
                                            </NavLink>
                                        </div>

                                        {this.Auth.loggedIn() && this.state.albums.length > 0
                                            ? <div className="auth-album-detail-container">
                                                <a id={album.id} onClick={this.albumDetails.bind(this)} className="btn btn-default" >Details</a>
                                                <a id={album.id} className="btn btn-default" onClick={this.editAlbum.bind(this)} >Edit </a>
                                                <a id={album.id} type="submit" onClick={this.deleteAlbum.bind(this)} className="btn btn-default">Delete</a>
                                            </div>
                                            : <p></p>}


                                    </div>

                                )}
                            </div>}
                        {contents}
                    </div>
                </div>
            </Aux>
        )
    }
}

const mapStateToProps = (state) => {     
    return {  
       data: state.data     
    } 
}
const mapDispatchToProps = (dispatch) => {
     return {
         onGetData: (url, props) => dispatch(repositoryActions.getData(url, props))     
    } 
} 
export default connect(mapStateToProps, mapDispatchToProps)(Albums);