import React, { Component } from 'react';

export class About extends Component {
  displayName = About.name

  render() {
    return (
        <div><div className="panel-heading text-center  golden-content">
                       <h1>About Us</h1>
                       <h4 className="red-header golden-content">Mission</h4>
                   </div>
                   <div className="panel-body  golden-content">
                       <blockquote>
                           <p>
                               The purpose of the chapter is : (1) To maintain a working relationship with the University;
                               (2) To promote interest in the University among prospective students;
                               (3) To promote fellowship among the alumni; and
                               (4) To promote and maintain a positive image of the University in the community.
                           </p>
                       </blockquote>
                       <p className="text-center  golden-content">
                           For More GSU Information : <a href="http://www.gram.edu/aboutus/history/" target="_blank">Grambling University History</a>
                       </p>
                   </div>
        </div>
    );
  }
}
