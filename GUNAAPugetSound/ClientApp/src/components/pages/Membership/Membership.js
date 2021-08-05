import React, { Component } from 'react';

export class Membership extends Component {
  displayName = Membership.name

  render() {
    return (
        <div><div className="panel-heading text-center  golden-content">
            <h1>Membership</h1>
            <h4 className="red-header">Alumni Association Dues Structure</h4>
        </div>
            <div className="panel-body   golden-content">
                <dl className="text-center  golden-content">
                    <dt>GUNAA</dt>
                    <dd>National Dues (Yearly) $70</dd>
                    <dd>Life Membership (Single) $500</dd>
                    <dd>Life Membership (Couples) $750</dd>
                </dl>
                <dl className="text-center   golden-content">
                    <dt>GUNAA Puget Sound Chapter</dt>
                    <dd>Local Dues Regular Members $50</dd>
                    <dd>Local Dues Associate Members (family/friends) $35</dd>
                </dl>
                <p className="text-center   golden-content">
                    <a href="../dist/wwwroot/content/Membership Application.docx" download>Download Membership Application</a>
                </p>
            </div>
        </div>
    );
  }
}
