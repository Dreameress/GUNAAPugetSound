import React, { Component } from 'react';
import '../Calendar.css';
import BigCalendar from 'react-big-calendar'
import events from '../Events'
import moment from 'moment'

const propTypes = {};
const localizer = BigCalendar.momentLocalizer(moment);

export class Calendar extends Component {
  displayName = Calendar.name
  constructor() {
    super(...arguments);
    this.handleSelect = this.handleSelect.bind(this);
    this.state = { events };
}
handleSelect = ({ start, end }) => {
    const title = window.prompt('New Event name')
    if (title)
      this.setState({
        events: [
          ...this.state.events,
          {
            start,
            end,
            title,
          },
        ],
      })
  }

  render() {
    const { localizer } = this.props
    return (
        <div> <div className="panel-heading text-center   golden-content">
        <h1>Calendar</h1>
        <h4 className="red-header">Keeping you udpated with Events, Meetings, and more from GUNAA Puget Sound</h4>
    </div>
        <div className="panel-body calendar-body">
        <BigCalendar
          selectable
          localizer={localizer}
          events={this.state.events}
          defaultView={BigCalendar.Views.MONTH}
          defaultDate={new Date(new Date().setHours(new Date().getHours() + 9))}
          onSelectEvent={event => alert(event.title)}
          onSelectSlot={this.handleSelect}
        />
        </div>
        </div>
    );
  }
}

