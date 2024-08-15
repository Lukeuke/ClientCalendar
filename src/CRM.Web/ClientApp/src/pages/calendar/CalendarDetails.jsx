import React from 'react';
import {useParams} from "react-router-dom";
import {gql, useQuery} from "@apollo/client";

function CalendarDetails() {
  
  const {calendarId, bookingId} = useParams();

  const bookingDetails = gql`
  {
    calendar(
      id: "${calendarId}"
      where: { bookings: { all: { id: { eq: "${bookingId}" } } } }
    ) {
      bookings {
        end
        id
        serviceTypeId
        start
        title
        client {
          address
          fullName
          phoneNumber
          shortName
        }
        serviceType {
          name
          price
        }
      }
    }
  }
`
  const { data, loading, error } = useQuery(bookingDetails);

  if (loading) return "Loading...";
  if (error) return <pre>{error.message}</pre>

  return (
      <div className="p-6 bg-white rounded-lg shadow-lg">
        <div className="text-2xl font-bold text-gray-800 mb-4">
          {data.calendar.bookings[0].title}
        </div>

        <div className="mb-4">
          <div className="text-lg font-semibold text-gray-700">Client Details:</div>
          <div className="ml-4">
            <p className="text-gray-600"><span className="font-medium">Name:</span> {data.calendar.bookings[0].client.fullName}</p>
            <p className="text-gray-600"><span className="font-medium">Phone:</span> {data.calendar.bookings[0].client.phoneNumber}</p>
            <p className="text-gray-600"><span className="font-medium">Address:</span> {data.calendar.bookings[0].client.address}</p>
          </div>
        </div>

        <div className="mb-4">
          <div className="text-lg font-semibold text-gray-700">Service Details:</div>
          <div className="ml-4">
            <p className="text-gray-600"><span className="font-medium">Service:</span> {data.calendar.bookings[0].serviceType.name}</p>
            <p className="text-gray-600"><span className="font-medium">Price:</span> ${data.calendar.bookings[0].serviceType.price}</p>
          </div>
        </div>

        <div className="text-gray-500 text-sm mb-2">
          <span className="font-medium">Calendar ID:</span> {calendarId}
        </div>
        <div className="text-gray-500 text-sm mb-4">
          <span className="font-medium">Booking ID:</span> {bookingId}
        </div>
      </div>
  );
}

export default CalendarDetails;