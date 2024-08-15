import Home from "./components/Home";
import CalendarPage from "./pages/calendar/CalendarPage";
import AddCustomer from "./pages/calendar/AddCustomer";
import Authorized from "./components/auth/Authorized";
import SignIn from "./pages/auth/SignIn";
import SignUp from "./pages/auth/SIgnUp";
import Calendars from "./pages/calendar/Calendars";
import CreateCalendar from "./pages/calendar/CreateCalendar";
import CalendarDetails from "./pages/calendar/CalendarDetails";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/calendar/:id',
    element: <Authorized>
                <CalendarPage />
            </Authorized>
  },
  {
    path: '/calendars',
    element: <Authorized>
      <Calendars />
    </Authorized>
  },
  {
    path: '/calendar/:id/customer/add',
    element:
        <Authorized> 
          <AddCustomer />
        </ Authorized>
  }, 
  {
      path: '/sign-in',
      element: <SignIn />
  },
  {
    path: '/sign-up',
    element: <SignUp />
  },
  {
    path: '/calendar/create',
    element: <CreateCalendar />
  },
  {
    path: '/calendar/:calendarId/details/:bookingId',
    element: <CalendarDetails />
  }
];

export default AppRoutes;
