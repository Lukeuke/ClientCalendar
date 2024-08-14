import Home from "./components/Home";
import CalendarPage from "./pages/CalendarPage";
import AddCustomer from "./pages/AddCustomer";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/calendar',
    element: <CalendarPage />
  },
  {
    path: '/customer/add',
    element: <AddCustomer />
  },
];

export default AppRoutes;
