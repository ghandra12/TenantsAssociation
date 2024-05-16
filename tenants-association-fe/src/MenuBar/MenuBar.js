import React, { useContext } from "react";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import IconButton from "@mui/material/IconButton";
import AppBar from "@mui/material/AppBar";
import Button from "@mui/material/Button";
import AppRoutes from "../AppRoute/AppRoute";
import UserContext from "../Services/UserContext";

const MenuBar = (props, children) => {
  const { setUser } = useContext(UserContext);

  const navigate = useNavigate();
  const [loggedIn, setLoggedIn] = useState(false);
  const [isAdmin, setIsAdmin] = useState(false);
  useEffect(() => {
    if (localStorage.getItem("authenticated")) {
      setLoggedIn(true);
      setUser(localStorage.getItem("userId"));
    }
    if (sessionStorage.getItem("authenticated")) {
      setLoggedIn(true);
      setUser(sessionStorage.getItem("userId"));
    }
    setIsAdmin(
      sessionStorage.getItem("userType") === "1" ||
        localStorage.getItem("userType") === "1"
    );
  }, [setUser]);

  const logOutHandler = () => {
    localStorage.removeItem("authenticated");
    sessionStorage.removeItem("authenticated");
    localStorage.removeItem("token");
    sessionStorage.removeItem("token");
    localStorage.removeItem("userType");
    sessionStorage.removeItem("userType");
    setLoggedIn(false);
    navigate("/");
  };

  // const onNavigateToNeedHelp = () => {
  //   navigate("/needHelp");
  // };
  const onNavigateToPollsHistory = () => {
    navigate("/pollshistory");
  };
  const onDashboardNavigate = () => {
    if (isAdmin) navigate("/adminhome");
    else navigate("/tenanthome");
  };
  const onLogoNavigate = () => {
    if (loggedIn) {
      onDashboardNavigate();
    } else navigate("/");
  };
  const onContactNavigate = () => {
    navigate("/contact");
  };
  const onInvoicesNavigate = () => {
    navigate("/invoices");
  };
  const onNavigateToYourAccount = () => {
    navigate("/youraccount");
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
          <Typography
            variant="h6"
            component="div"
            sx={{ flexGrow: 1, cursor: "pointer" }}
            onClick={onLogoNavigate}
          >
            TenantsAssociation
          </Typography>

          {loggedIn && (
            <Button color="inherit" onClick={onDashboardNavigate}>
              Dashboard
            </Button>
          )}
          {!isAdmin && loggedIn && (
            <Button color="inherit" onClick={onInvoicesNavigate}>
              Invoices
            </Button>
          )}
          {loggedIn && (
            <Button color="inherit" onClick={onNavigateToYourAccount}>
              Your account
            </Button>
          )}
          {loggedIn && isAdmin && <Button color="inherit">Services</Button>}
          {loggedIn && !isAdmin && (
            <Button color="inherit" onClick={onContactNavigate}>
              Contact
            </Button>
          )}
          {loggedIn && (
            <Button color="inherit" onClick={onNavigateToPollsHistory}>
              Polls history
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
