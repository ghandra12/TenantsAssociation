import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import API from "../Services/api";
const Contact = () => {
  const [message, setMessage] = useState("");
  const navigate = useNavigate();
  const onChangeMessageHandler = (event) => {
    setMessage(event.target.value);
  };
  const onSubmitHandler = () => {
    API.post("Message/addmessage", {
      description: message,
    }).then((response) => {
      alert("Message was sent!!!");
      navigate("/tenanthome");
    });
  };
  return (
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
          <Typography color="primary" variant="h5">
            {" "}
            Tell us your problem! <br />
            Your message will be redirected to your administrator.
          </Typography>
        </Grid>
        <Grid item xs={6}>
          <TextField
            id="outlined-multiline-static"
            label="Your message"
            variant="outlined"
            onChange={onChangeMessageHandler}
            value={message}
            multiline
            maxRows={10}
          />
        </Grid>

        <Grid item xs={6}>
          <Button
            color="secondary"
            type="submit"
            onClick={onSubmitHandler}
            variant="contained"
          >
            Send
          </Button>
        </Grid>
        <Grid item xs={6}>
          <Typography color="primary" variant="h7">
            {" "}
            <b> -Or call us-</b> <br />
            0777120000
            <br />
            0722211144
          </Typography>
        </Grid>
      </Grid>
    </Box>
  );
};
export default Contact;
