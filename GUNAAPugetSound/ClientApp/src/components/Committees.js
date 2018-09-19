import React, { Component } from 'react';

export class Committees extends Component {
  displayName = Committees.name

  constructor(props) {
    super(props);
    this.state = { members: [], loading: true };

    fetch('api/Members/CommitteeMembers')
      .then(response => response.json())
      .then(data => {
        this.setState({ members: data, loading: false });
      });
  }

  static renderCommitteesSection(members) {
    return (
      <div>
            {members.map((member, index) =>
                <section className="leader-panel"  key={index}>

                    <div className="col-sm-6" >
                        <span><strong>{member.committee}</strong></span>
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
      ? <p><em>Loading...</em></p>
      : Committees.renderCommitteesSection(this.state.members);

    return (
        <div>
        <div className="panel-heading text-center golden-content">
            <h1>Committees</h1>
            <h4 className="red-header">Committee Chairs for Grambling University National Alumni Association of Puget Sound</h4>
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
