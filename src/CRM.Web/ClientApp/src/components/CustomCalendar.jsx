﻿import React from "react";
import { Calendar, momentLocalizer } from "react-big-calendar";
import moment from "moment";

import "react-big-calendar/lib/css/react-big-calendar.css";

import 'moment/locale/pl'; // TODO: add more language support

const messages = {
    month: 'Miesiąc',
    week: 'Tydzień',
    day: 'Dzień',
    today: 'Dziś',
    previous: 'Poprzedni',
    next: 'Następny',
    agenda: 'Agenda',
    noEvents: 'Brak wydarzeń',
    allDay: 'Cały dzień',
    more: 'Więcej',
};

const localizer = momentLocalizer(moment);
moment.locale('pl');

const CustomCalendar = ({ events }) => {
    const handleEventClick = (event) => {
        console.log(event)
        window.location.replace(`/calendar/${event.calendarId}/details/${event.id}`)
    };

    const eventPropGetter = (event) => {
        let backgroundColor = event.color;

        return {
            style: {
                backgroundColor,
                borderColor: backgroundColor,
                color: 'white'
            }
        };
    };
    
    return (
        <div>
            <Calendar
                localizer={localizer}
                events={events}
                startAccessor="start"
                endAccessor="end"
                style={{ height: 700 }}
                messages={messages}
                onSelectEvent={handleEventClick}
                eventPropGetter={eventPropGetter}
            />
        </div>
    );
};

export default CustomCalendar;
