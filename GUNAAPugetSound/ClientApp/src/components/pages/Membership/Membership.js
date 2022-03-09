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
                    <dt style={{ fontSize: 20}} >GUNAA</dt>
                    <br />
                    <dd>Recent Graduate - FREE (For the 1st year)</dd>
                    <dd>Associate Membership $65</dd>
                    <dd>National Dues (Yearly) $70</dd>
                    <dd>Life Membership (Single) $1000</dd>
                    <dd>Life Membership (Couples) $1500</dd>
                </dl>
                <br />
                <dl className="text-center   golden-content">
                    <dt  style={{ fontSize: 20}}>GUNAA Puget Sound Chapter</dt>
                    <br />
                    <dd>Local Dues Regular Members $50</dd>
                    <dd>Local Dues Associate Members (family/friends) $35</dd>
                </dl>
                <br />
                <p className="text-center   golden-content">
                    <a href="../dist/wwwroot/content/Membership Application.docx" download>Download Membership Application</a>
                </p>
            </div>
        </div>
    );
  }
}
