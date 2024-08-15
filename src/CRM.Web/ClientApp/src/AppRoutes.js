import Home from "./components/Home";
import CalendarPage from "./pages/CalendarPage";
import AddCustomer from "./pages/AddCustomer";
import Authorized from "./components/auth/Authorized";
import SignIn from "./pages/auth/SignIn";
import SignUp from "./pages/auth/SIgnUp";
import Calendars from "./pages/calendar/Calendars";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/calendar',
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
    path: '/customer/add',
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
  }
];

export default AppRoutes;
