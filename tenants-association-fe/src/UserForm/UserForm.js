import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import API from "../Services/api";
import FormGroup from "@mui/material/FormGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
const UserForm = () => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [isAdmin, setIsAdmin] = useState(false);
  const [apartment, setApartment] = useState(0);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();
  const onChangeFirstNameHandler = (event) => {
    setFirstName(event.target.value);
  };
  const onChangeLastNameHandler = (event) => {
    setLastName(event.target.value);
  };
  const onChangeEmailHandler = (event) => {
    setEmail(event.target.value);
  };
  const onChangePasswordHandler = (event) => {
    setPassword(event.target.value);
  };
  const onChangePhoneNumberHandler = (event) => {
    setPhoneNumber(event.target.value);
  };
  const onCheckIsAdminHandler = (event) => {
    debugger;
    setIsAdmin(event.target.checked);
  };
  const onChangeApartmentHandler = (event) => {
    setApartment(event.target.value);
  };
  const onSubmitHandler = (event) => {
    event.preventDefault();

    API.post("User/adduser", {
      firstName: firstName,
      lastName: lastName,
      phoneNumber: phoneNumber,
      password: password,
      email: email,
      isAdmin: isAdmin,
      apartmentNumber: apartment,
    }).then((response) => {
      navigate("/adminhome");
    });
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
            marginTop: 10,
          }}
        >
          <Grid item xs={6}>
            <TextField
              id="outlined-basic"
              label="First name"
              variant="outlined"
              value={firstName}
              onChange={onChangeFirstNameHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="outlined-basic"
              label="Last name"
              variant="outlined"
              value={lastName}
              onChange={onChangeLastNameHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="outlined-basic"
              label="Phone number"
              variant="outlined"
              value={phoneNumber}
              onChange={onChangePhoneNumberHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="outlined-basic"
              label="Apartment number"
              variant="outlined"
              value={apartment}
              onChange={onChangeApartmentHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="outlined-basic"
              label="Email"
              variant="outlined"
              value={email}
              onChange={onChangeEmailHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="outlined-basic"
              label="Password"
              variant="outlined"
              value={password}
              onChange={onChangePasswordHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <FormGroup>
              <FormControlLabel
                control={
                  <Checkbox
                    inputProps={{ "aria-label": "controlled" }}
                    onChange={onCheckIsAdminHandler}
                  />
                }
                label="Admin"
              />
            </FormGroup>
          </Grid>
          <Grid item xs={6}>
            <Button
              color="secondary"
              type="submit"
              onClick={onSubmitHandler}
              variant="contained"
            >
              Create user
            </Button>
          </Grid>
        </Grid>
      </Box>
    </form>
  );
};
export default UserForm;
