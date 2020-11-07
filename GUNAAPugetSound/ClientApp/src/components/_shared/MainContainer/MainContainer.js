import React from 'react';
import PropTypes from 'prop-types';

const propTypes = {
  className: PropTypes.string,
  content: PropTypes.object.isRequired,
  officers: PropTypes.object,
  committees: PropTypes.object,
  events: PropTypes.object,
  photos: propTypes.object
};

const hide = {
  display: 'none'
};

const show = {
  display: 'block'
};

const MainContainer = ({content, officers, committees, ...otherProps}) => {
  
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