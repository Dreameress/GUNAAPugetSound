import React, { Component } from 'react';

export class Contact extends Component {
  displayName = Contact.name

  render() {
    return (
        <div>
              <div className="panel-heading text-center  golden-content">
                <h1>Contact Us</h1>
            </div>
            <div className="panel-body golden-content">
        
        <address className="text-center  golden-content">
            <strong>Grambling University National Alumni Association</strong><br />
            <strong>Puget Sound Chapter</strong><br />
            Post Office Box 18321<br />
            Seattle, Washington 98118<br />
            <a href="mailto:gunaapugetsound@hotmail.com">gunaapugetsound@hotmail.com</a>
        </address>
        <p className="text-center golden-content">
            Visit <a href="http://www.gram.edu" target="_blank"> Grambing State University</a>
        </p>
    </div>
</div>
    );
  }
}
