import React, { useState, useContext } from "react";
import { useNavigate } from "react-router-dom";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import Checkbox from "@mui/material/Checkbox";
import FormControlLabel from "@mui/material/FormControlLabel";
import API from "../Services/api";
import UserContext from "../Services/UserContext";
const LoginPage = (props) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [remember, setRemember] = useState();
  const { setUser } = useContext(UserContext);

  const navigate = useNavigate();

  const onChangeEmailHandler = (event) => {
    setEmail(event.target.value);
  };
  const onChangePasswordHandler = (event) => {
    setPassword(event.target.value);
  };

  const onSubmitHandler = (event) => {
    event.preventDefault();

    if (email.length < 8 || password.length < 8) {
      alert("Email and password should have at least 8 characters!");
      return;
    }

    API.post("user", {
      email: email,
      password: password,
    })
      .then((response) => {
        if (remember) {
          localStorage.setItem("authenticated", true);
          localStorage.setItem("userType", response.data.loginResult);
          localStorage.setItem("userId", response.data.userId);
          localStorage.setItem("token", response.data.token);
        } else {
          sessionStorage.setItem("authenticated", true);
          sessionStorage.setItem("userType", response.data.loginResult);
          sessionStorage.setItem("userId", response.data.userId);
          sessionStorage.setItem("token", response.data.token);
        }
        props.setLoggedIn(true);

        setUser(response.data.userId);

        if (response.data === 2) {
          navigate("/tenanthome");
        } else {
          navigate("/adminhome");
        }
      })
      .catch((error) => {
        alert(error.response.data);
      });
  };
  const rememberMeHandler = (event) => {
    setRemember(event.target.value);
  };
  return (
    <form>
      <Box sx={{ flexGrow: 1 }}>
        <Grid
          container
          direction="column"
          justifyContent="center"
          alignItems="center"
          spacing={3}
          style={{
            position: "absolute",
            left: "50%",
            top: "50%",
            transform: "translate(-50%, -50%)",
          }}
        >
          <Grid item xs={6}>
            <TextField
              id="outlined-basic"
              label="Email"
              variant="outlined"
              onChange={onChangeEmailHandler}
              value={email}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="outlined-password-input"
              label="Password"
              type="password"
              autoComplete="current-password"
              onChange={onChangePasswordHandler}
              value={password}
            />
          </Grid>
          <Grid item xs={6}>
            <FormControlLabel
              value={remember}
              control={<Checkbox />}
              label="Remember me"
              labelPlacement="end"
              onClick={rememberMeHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <Button
              color="secondary"
              type="submit"
              onClick={onSubmitHandler}
              variant="contained"
            >
              Log in
            </Button>
          </Grid>
        </Grid>
      </Box>
    </form>
  );
};
export default LoginPage;
