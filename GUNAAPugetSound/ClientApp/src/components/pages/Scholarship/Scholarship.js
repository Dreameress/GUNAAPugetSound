import React, { Component } from 'react';

export class Scholarship extends Component {
  displayName = Scholarship.name

  render() {
    return (
        <div>
            <div className="panel-heading text-center  golden-content">
                <h1>Scholarship</h1>
                <h4 className="red-header">Scholarship Program</h4>
            </div>
            <div className="panel-body golden-content">
                <p className="text-center">
                    The Puget Sound Chapter of Grambling University National Alumni Association
                    awards two scholarships annually to students who plan to attend Grambling State University.
                       </p>
                <p className="text-center">
                    <a href="/content/documents/GUNAAScholarshipApplication2020.docx"
                     download>Download Scholarship Application</a> 
                    |<a href="/" asp-controller="Forms" asp-action="ScholarshipForm">Fill Out Scholarship Application</a> 
                </p>
                <p className="text-center">
                    <a href="/content/documents/GUNAAScholarshipLetter2020.docx" download>Download Scholarship Letter</a>
                </p>
                <p className="text-center">
                    <a href="/content/documents/GUNAAScholarshipFlyer2020.docx" download>Download Scholarship Flyer</a>
                </p>
            </div>
        </div>
    );
  }
}
