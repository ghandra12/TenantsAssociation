import React, { useState } from "react";
import MenuBar from "../MenuBar/MenuBar";
//import { useNavigate } from "react-router-dom";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import Checkbox from "@mui/material/Checkbox";
import FormControlLabel from "@mui/material/FormControlLabel";
function LoginPage() {
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  //const navigate = useNavigate();
  const onChangeEmailHandler = (event) => {
    setEmail(event.target.value);
  };
  const onChangePasswordHandler = (event) => {
    setPassword(event.target.value);
  };
  //   const onClickHandler = () => {
  //     //navigate("");
  //     //Navigam la HomePage;
  //   };
  return (
    <form>
      <Box sx={{ flexGrow: 1 }}>
        <MenuBar></MenuBar>
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
              value="remember me"
              control={<Checkbox />}
              label="Remember me"
              labelPlacement="end"
            />
          </Grid>
          <Grid item xs={6}>
            <Button color="secondary" type="submit" variant="contained">
              Log in
            </Button>
          </Grid>
        </Grid>
      </Box>
    </form>
  );
}
export default LoginPage;
