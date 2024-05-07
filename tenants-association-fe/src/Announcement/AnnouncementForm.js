import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import API from "../Services/api";
import { DemoContainer } from "@mui/x-date-pickers/internals/demo";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 450,
  height: 450,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};
const AnnouncementForm = (props) => {
  const [title, setTitle] = useState();
  const [expirationDate, setExpirationDate] = useState();
  const [description, setDescription] = useState();
  const onChangeExpirationDateHandler = (event) => {
    setExpirationDate(event);
  };
  const onChangeDescriptionHandler = (event) => {
    setDescription(event.target.value);
  };
  const onChangeTitleHandler = (event) => {
    setTitle(event.target.value);
  };
  const onSubmitHandler = (event) => {
    event.preventDefault();

    API.post("Announcement/addannouncement", {
      title: title,
      expirationDate: expirationDate,
      content: description,
    }).then((response) => {
      props.handleClose();
    });
  };
  return (
    <Box sx={style}>
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
                id="standard-basic"
                label="Title"
                variant="standard"
                value={title}
                onChange={onChangeTitleHandler}
                size="small"
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                id="standard-multiline-static"
                label="Description"
                multiline
                rows={4}
                variant="standard"
                value={description}
                onChange={onChangeDescriptionHandler}
              />
            </Grid>
            <Grid item xs={6}>
              <LocalizationProvider dateAdapter={AdapterDayjs}>
                <DemoContainer components={["DatePicker"]}>
                  <DatePicker
                    sx={{ width: 225 }}
                    label="Expiration date"
                    value={expirationDate}
                    onChange={onChangeExpirationDateHandler}
                  />
                </DemoContainer>
              </LocalizationProvider>
            </Grid>

            <Grid item xs={6}>
              <Button
                color="secondary"
                type="submit"
                onClick={onSubmitHandler}
                variant="contained"
              >
                Send to tenants
              </Button>
            </Grid>
          </Grid>
        </Box>
      </form>
    </Box>
  );
};
export default AnnouncementForm;
