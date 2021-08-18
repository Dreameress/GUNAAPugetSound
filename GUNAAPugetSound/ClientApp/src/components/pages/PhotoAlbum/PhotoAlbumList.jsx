import React, { Component } from "react";
import { Table, Col, Row } from "react-bootstrap";
import { Link, NavLink } from "react-router-dom";
import Aux from "../../../hoc/Auxiliary/Auxiliary";
import { connect } from "react-redux";
import * as repositoryActions from "../../../store/actions/repositoryActions";
import ContainerHeader from "../../molecules/ContainerHeader/ContainerHeader";
import Icon from './../../atoms/Icon';
export class PhotoAlbumList extends Component {
  // componentDidMount = () => {
  //     let url = '/api/photoAlbum/photos';
  //     this.props.onGetData(url, { ...this.props });
  // }

  render() {
    let photoAlbums = [];
    // if (this.props.data && this.props.data.length > 0) {
    //     photoAlbums = this.props.data.map((album) => {
    //         return (
    //             <PhotoAlbum key={album.id} album={album} {...this.props} />
    //         )
    //     })
    // }

    return (
      <Aux>
        <div>
          <ContainerHeader
            headerText="Photos"
            headerMessage="Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more"
          />
          <div className="panel-body text-center golden-content">
            <div className="albumsContainer">{photoAlbums}</div>
            <div className="authorized-options">
              <div className="auth-album-container">
                <NavLink
                  to={"/addAlbum"}
                  style={{ top: 40, position: "relative" }}
                  className="btn btn-default-gold btn-m navbar-btn"
                >
                  Add Album<Icon plus style={{ fontSize: 10, marginLeft: 5 }}></Icon>
                </NavLink>
              </div>
            </div>
          </div>
        </div>
      </Aux>
    );
  }
}

// const mapStateToProps = (state) => {
//     return {
//        data: state.data
//     }
// }
// const mapDispatchToProps = (dispatch) => {
//      return {
//          onGetData: (url, props) => dispatch(repositoryActions.getData(url, props))
//     }
// }

export default PhotoAlbumList;
//export default connect(mapStateToProps, mapDispatchToProps)(PhotoAlbumList);
