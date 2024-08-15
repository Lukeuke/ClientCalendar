import React, {useEffect, useState} from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export const NavMenu = () => {
  const [collapsed, setCollapsed] = useState(true);
  const [token, setToken] = useState();

  useEffect(() => {
    
    let jwt = window.localStorage.getItem("jwt")
    setToken(jwt);
    
  }, [])
  
  const toggleNavbar = () => {
    setCollapsed(!collapsed);
  };

  return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to="/">CRM.Web</NavbarBrand>
          <NavbarToggler onClick={toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/calendars">Kalendarze</NavLink>
              </NavItem>
              {token ? null :
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/sign-in">Sign In</NavLink>
                </NavItem>
              }
            </ul>
          </Collapse>
        </Navbar>
      </header>
  );
};
