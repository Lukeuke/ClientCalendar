import React, {useEffect} from 'react';
import { useQuery, gql } from "@apollo/client";
import { Link } from 'react-router-dom';

function Calendars() {

  const calendarsQuery = gql`
  {
    allCalendars {
      createdAt
      id
      name
    }
  }
`;

  const { data, loading, error } = useQuery(calendarsQuery);

  if (loading) return "Loading...";
  if (error) return <pre>{error.message}</pre>

  return (
      <div className="max-w-4xl mx-auto p-4">
        <h1 className="text-3xl font-bold mb-6 text-center">Your Calendars</h1>
        
        <div className="flex justify-center mb-4">
          <a
              href="/calendar/create"
              className="inline-block bg-blue-600 text-white font-semibold py-2 px-4 rounded-lg shadow hover:bg-blue-700 transition-colors duration-200"
          >
            Create
          </a>
        </div>
        
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
          {data.allCalendars.map((calendar) => (
              <div
                  className="bg-white shadow-md rounded-lg p-6 transition-transform transform hover:scale-105"
                  key={calendar.id}
              >
                <h2 className="text-xl font-semibold text-blue-600 mb-2">
                  <Link to={`/calendar/${calendar.id}`}>{calendar.name}</Link>
                </h2>
                <p className="text-gray-500">Created at: {new Date(calendar.createdAt * 1000).toLocaleDateString()}</p>
              </div>
          ))}
        </div>
      </div>
  );
}

export default Calendars;