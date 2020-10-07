import React, { Component } from 'react';
import '../../../styles/Calendar.css';
import ReactModal from 'react-modal';
import BigCalendar from 'react-big-calendar';
import events from '../../../helpers/Events';
import moment from 'moment';


const localizer = BigCalendar.momentLocalizer(moment);
const showCalendar = {
  visibility: 'visible'
};

const hideCalendar = {
  visibility: 'hidden'
};

export class Calendar extends Component {
  displayName = Calendar.name
  constructor() {
    super(...arguments);
    this.handleSelect = this.handleSelect.bind(this);
    this.hideModal = this.hideModal.bind(this);
    this.getParent = this.getParent.bind(this);
    this.updateTitle = this.updateTitle.bind(this);
    this.updateStart = this.updateStart.bind(this);
    this.updateEnd = this.updateEnd.bind(this);
    this.state = {
      events: events, showEventModal: false, selectedEventStart: new Date(), selectedEventEnd: new Date(), selectedEventTitle: ''
    };
  }

  handleSelect = ({ start, end }) => {
    this.setState({
      selectedEventStart: start,
      selectedEventEnd: end,
      showEventModal: true
    });
  }

  updateTitle = (event) => {
    this.setState({
      selectedEventTitle: event.target.value
    });
  };

  updateStart = (event) => {
    this.setState({
      selectedEventStart: event.target.value
    });
  };

  updateEnd = (event) => {
    this.setState({
      selectedEventEnd: event.target.value
    });
  };

  showModal = (event) => {
    this.setState({
      showEventModal: true,
      selectedEvent: event
    });
  };

  hideModal = () => {
    this.setState({
      showEventModal: false,
      selectedEventStart: null,
      selectedEventEnd: null,
      selectedEventTitle: ''
    });
  };

  getParent = () => {
    return document.querySelector('#modalParent');
  };

  render() {
    return (
      <div> <div className="panel-heading text-center   golden-content">
        <h1>Calendar</h1>
        <h4 className="red-header">Keeping you udpated with Events, Meetings, and more from GUNAA Puget Sound</h4>
      </div>
        <div id="modalParent" className="panel-body calendar-body">
          <BigCalendar style={this.state.showEventModal ? hideCalendar : showCalendar} selectable localizer={localizer} events={this.state.events} defaultView={BigCalendar.Views.MONTH} defaultDate={new Date(moment())} onSelectEvent={event => this.handleSelect(event)} onSelectSlot={this.handleSelect} views={{ month: true }} />
          <ReactModal className="calendar-modal" parentSelector={this.getParent} contentLabel="Minimal Modal Example" isOpen={this.state.showEventModal} onRequestClose={this.hideModal}>
            <p>Modal</p>
            <input className="calandar-modal-input-readonly" type="text" disabled placeholder={this.state.selectedEventStart} />
            <input className="calandar-modal-input-readonly" type="text" disabled placeholder={this.state.selectedEventEnd} />
            <input placeholder="Event Details" value={this.state.selectedEventTitle} onChange={this.updateTitle.bind(this)} />
            <div>
              <button className="calendar-modal-button" onClick={this.hideModal}><i className="fas fa-save" />Save</button>
              <button className="calendar-modal-button" onClick={this.hideModal}>Delete</button>
              <button className="calendar-modal-button" onClick={this.hideModal}>Close</button>
            </div>
          </ReactModal>
        </div>
      </div>
    );
  }
}

