import React from "react";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { useState } from "react";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Button from "@mui/material/Button";
import API from "../Services/api";
import Typography from "@mui/material/Typography";
import Paper from "@mui/material/Paper";
import TextField from "@mui/material/TextField";
const YourAccount = () => {
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");
  const onChangeEmail = (event) => {
    setEmail(event.target.value);
  };
  const onChangePassword = (event) => {
    setPassword(event.target.value);
  };
  const onSubmitChangeEmail = (event) => {
    event.preventDefault();
    if (email < 8) {
      alert("Email should have at least 8 characters!");
    } else {
      API.put("user/updateUserEmail", email, {
        headers: {
          "Content-Type": "application/json",
        },
      }).then(() => {
        alert("Email changed with success");
      });
    }
  };
  const onSubmitChangePassword = (event) => {
    event.preventDefault();
    if (password < 8) {
      alert("Password should have at least 8 characters!");
    } else {
      API.put("user/updateUserPassword", password, {
        headers: {
          "Content-Type": "application/json",
        },
      }).then(() => {
        alert("Password changed with success");
      });
    }
  };
  return (
    <Box
      display="flex"
      justifyContent="center"
      alignItems="center"
      minHeight="100vh"
      sx={{ ml: 20, mr: 20 }}
    >
      <Paper elevation={24}>
        <div xs={12}>
          <Accordion sx={{ minWidth: 600 }}>
            <AccordionSummary
              expandIcon={<ExpandMoreIcon />}
              aria-controls="panel2-content"
              id="panel2-header"
            >
              <Grid item xs={12}>
                <Typography>Change email</Typography>
              </Grid>
            </AccordionSummary>
            <AccordionDetails>
              <Grid item xs={12}>
                <TextField
                  id="standard-basic"
                  label="New email"
                  variant="standard"
                  value={email}
                  onChange={onChangeEmail}
                />
              </Grid>

              <Grid item xs={4} mb={2} mt={2}>
                <Button
                  variant="contained"
                  color="info"
                  onClick={onSubmitChangeEmail}
                  size="small"
                  type="submit"
                >
                  Submit
                </Button>
              </Grid>
            </AccordionDetails>
          </Accordion>
          <Accordion>
            <AccordionSummary
              expandIcon={<ExpandMoreIcon />}
              aria-controls="panel2-content"
              id="panel2-header"
            >
              <Grid item xs={12}>
                <Typography>Change password</Typography>
              </Grid>
            </AccordionSummary>
            <AccordionDetails>
              <Grid item xs={12}>
                <TextField
                  id="standard-basic"
                  label="New password"
                  variant="standard"
                  value={password}
                  onChange={onChangePassword}
                />
              </Grid>

              <Grid item xs={4} mb={2} mt={2}>
                <Button
                  variant="contained"
                  color="info"
                  onClick={onSubmitChangePassword}
                  size="small"
                  type="submit"
                >
                  Submit
                </Button>
              </Grid>
            </AccordionDetails>
          </Accordion>
        </div>
      </Paper>
    </Box>
  );
};
export default YourAccount;
