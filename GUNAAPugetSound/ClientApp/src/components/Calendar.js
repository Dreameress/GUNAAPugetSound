import React, { Component } from 'react';
import {
    ScheduleComponent, ViewsDirective, ViewsModelDirective, Month, Inject
} from '@syncfusion/ej2-react-schedule';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';

export class Calendar extends Component {
  displayName = Calendar.name
  constructor() {
    super(...arguments);
    this.dataManger = new DataManager({
        url: 'https://js.syncfusion.com/demos/ejservices/api/Schedule/LoadData',
        adaptor: new WebApiAdaptor,
        crossDomain: true
    });
}

  render() {
    return (
        <div> <div className="panel-heading text-center   golden-content">
        <h1>Calendar</h1>
        <h4 className="red-header">Keeping you udpated with Events, Meetings, and more from GUNAA Puget Sound</h4>
    </div>
        <div className="panel-body">
        <ScheduleComponent cssClass='schedule-header-bar' id='schedule'
                    selectedDate={new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate())}>
                    <ViewsDirective>
                        <ViewsModelDirective option='Month' />
                    </ViewsDirective>
                    <Inject services={[Month]} />
                </ScheduleComponent>
        </div>
        </div>
    );
  }
}
