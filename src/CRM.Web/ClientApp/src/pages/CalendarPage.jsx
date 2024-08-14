import CustomCalendar from "../components/CustomCalendar";
import React, {useEffect, useState} from "react";

const CalendarPage = () => {

/*    const [events, setEvents] = useState();
    
    useEffect(() => {
        fetch("api/calendar", {
            
        })
            .then(res => {
                console.log(res)
                return res.json()
            })
            .then(data => setEvents(data));
       
    }, [])*/
    
/*    if (events == null) {
       return <>Loading...</> 
    }*/

    const events = [
        {
            id: 1,
            title: "Client Meeting with John Doe",
            start: new Date(1723581349 * 1000), // Convert to milliseconds
            end: new Date(1728726000 * 1000)    // Convert to milliseconds
        },
        {
            id: 2,
            title: "Project Review with Jane Smith",
            start: new Date(1728808800 * 1000), // Convert to milliseconds
            end: new Date(1728812400 * 1000)    // Convert to milliseconds
        },
        {
            id: 3,
            title: "Call with Alex Johnson",
            start: new Date(1722891800 * 1000), // Convert to milliseconds
            end: new Date(1722893000 * 1000)    // Convert to milliseconds
        }
    ];
    
    return (
        <>
            <div className="h1">Kalendarz wizyt klientów</div>
            <CustomCalendar events={events} />
            <a href="/customer/add">Dodaj klienta</a>
        </>
    );
};

export default CalendarPage;