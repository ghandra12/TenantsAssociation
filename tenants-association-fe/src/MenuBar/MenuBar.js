import React from "react";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import IconButton from "@mui/material/IconButton";
import AppBar from "@mui/material/AppBar";
import Button from "@mui/material/Button";
import AppRoutes from "../AppRoute/AppRoute";
const MenuBar = (props, children) => {
  const navigate = useNavigate();
  const [loggedIn, setLoggedIn] = useState(false);
  const [isAdmin, setIsAdmin] = useState(false);
  useEffect(() => {
    if (localStorage.getItem("authenticated")) {
      setLoggedIn(true);
    }
    if (sessionStorage.getItem("authenticated")) {
      setLoggedIn(true);
    }
    setIsAdmin(sessionStorage.getItem("userType") === "2");
  }, []);

  const logOutHandler = () => {
    localStorage.removeItem("authenticated");
    sessionStorage.removeItem("authenticated");
    localStorage.removeItem("userType");
    sessionStorage.removeItem("userType");
    setLoggedIn(false);
    navigate("/");
  };

  const onNavigateToNeedHelp = () => {
    navigate("/needHelp");
  };
  return (
    <div>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          ></IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            TenantsAssociation
          </Typography>
          {!loggedIn && (
            <Button color="inherit" onClick={onNavigateToNeedHelp}>
              Need Help?
            </Button>
          )}
          {loggedIn && (
            <Button color="inherit" onClick={logOutHandler}>
              Dashboard
            </Button>
          )}
          {!isAdmin && loggedIn && (
            <Button color="inherit" onClick={logOutHandler}>
              Invoices
            </Button>
          )}
          {loggedIn && (
            <Button color="inherit" onClick={logOutHandler}>
              Your account
            </Button>
          )}
          {loggedIn && isAdmin && (
            <Button color="inherit" onClick={logOutHandler}>
              Services
            </Button>
          )}
          {loggedIn && !isAdmin && (
            <Button color="inherit" onClick={logOutHandler}>
              Contact
            </Button>
          )}
          {loggedIn && (
            <Button color="inherit" onClick={logOutHandler}>
              Logout
            </Button>
          )}
        </Toolbar>
      </AppBar>
      <AppRoutes loggedIn={loggedIn} setLoggedIn={setLoggedIn} />
    </div>
  );
};
export default MenuBar;
