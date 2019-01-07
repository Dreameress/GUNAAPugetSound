import React, { Component } from 'react';
import { Loading } from './Loading';

export class Officers extends Component {
  displayName = Officers.name

  constructor(props) {
    super(props);
    this.state = { members: [], loading: true };

    fetch('api/Members/Officers')
      .then(response => response.json())
      .then(data => {
        this.setState({ members: data, loading: false });
      });
  }

  static renderOfficersSection(members) {
    return (
      <div >
            {members.map((member, index) =>
          
                <section className="leader-panel" key={index}>

                    <div className="col-sm-6" >
                        <span><strong>{member.position}</strong></span>
                    </div>
                    <div className="col-sm-6">
                        <span>{member.nameFirst} {member.nameLast}</span>
                    </div>

                </section>
          
            )}
        </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <Loading />
      : Officers.renderOfficersSection(this.state.members);

    return (
      <div>
            <div className="panel-heading text-center  golden-content">
                <h1>Officers</h1>
                <h4 className="red-header">Leaders of Grambling University National Alumni Association of Puget Sound</h4>
            </div>
            <div className="panel-body  golden-content">
                <div className="row">
                {contents}
                </div>
            </div>

        </div>
    );
  }
}
