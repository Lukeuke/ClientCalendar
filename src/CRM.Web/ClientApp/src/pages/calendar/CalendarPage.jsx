import CustomCalendar from "../../components/CustomCalendar";
import React, {useEffect, useState} from "react";
import {gql, useQuery} from "@apollo/client";
import {useParams} from "react-router-dom";

const CalendarPage = () => {

    const { id } = useParams()
    
    const calendarQuery = gql`
    {
      calendar(id: "${id}") {
        name
        ownerId
        createdAt
        id
        bookings {
          clientId
          id
          serviceTypeId
          start
          end
          title
          client {
            address
            firstName
            fullName
            id
            lastName
            phoneNumber
            shortName
          }
        }
      }
    }
`;

    const { data, loading, error } = useQuery(calendarQuery);

    if (loading) return "Loading...";
    if (error) return <pre>{error.message}</pre>

    const events = data.calendar.bookings.map(booking => ({
        id: booking.id,
        calendarId: data.calendar.id,
        title: `${booking.client.shortName} - ${booking.title}`,
        start: new Date(booking.start * 1000),
        end: new Date(booking.end * 1000)
    }));
    
    return (
        <>
          <div className="h1">{data.calendar.name}</div>
          <CustomCalendar events={events} />
          <div className="mt-2 mb-2 text-xl sm:text-l">
            <a href={`calendar/${data.calendar.id}/customer/add`} className="underline">Dodaj klienta</a>
          </div>
          
          <div className="text-gray-500 text-sm mb-2">
              <span className="font-medium">Calendar ID:</span> {id}
          </div>
        </>
    );
};

export default CalendarPage;