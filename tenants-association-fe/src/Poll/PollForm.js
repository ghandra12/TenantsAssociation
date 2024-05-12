import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import API from "../Services/api";
import Typography from "@mui/material/Typography";
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
  height: 500,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};
const PollForm = (props) => {
  const [question, setQuestion] = useState();
  const [answers, setAnswers] = useState(["", ""]);
  const [expirationDate, setExpirationDate] = useState();

  const onChangeExpirationDate = (event) => {
    setExpirationDate(event);
  };
  const onChangeQuestionHandler = (event) => {
    setQuestion(event.target.value);
  };
  const handleAnswerChange = (e, index) => {
    const newAnswers = [...answers];
    newAnswers[index] = e.target.value;
    setAnswers(newAnswers);
  };
  const handleAddAnswer = () => {
    if (answers.length < 4) {
      setAnswers([...answers, ""]);
    } else alert("You can add maximum 4 answers");
  };
  const onSubmitHandler = (event) => {
    event.preventDefault();

    API.post("Poll/addpoll", {
      question: question,
      answers: answers,
      expirationDate: expirationDate,
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
              <Typography variant="h5" color="secondary">
                Create a poll
              </Typography>
            </Grid>
            <Grid item xs={6}>
              <TextField
                id="outlined-basic"
                label="Question"
                variant="outlined"
                value={question}
                onChange={onChangeQuestionHandler}
                size="small"
              />
            </Grid>
            <Grid item xs={6}>
              <Typography variant="h5" color="secondary">
                Add answers:
              </Typography>
            </Grid>
            <Grid item xs={6}>
              {answers.map((answer, index) => (
                <Grid item xs={12} mt={2} mb={2}>
                  <TextField
                    id="outlined-basic"
                    label="Answer"
                    variant="outlined"
                    key={index}
                    type="text"
                    value={answer}
                    size="small"
                    onChange={(e) => handleAnswerChange(e, index)}
                  />
                </Grid>
              ))}

              <Button
                color="secondary"
                variant="contained"
                onClick={handleAddAnswer}
              >
                +
              </Button>
            </Grid>
            <Grid item xs={6}>
              <LocalizationProvider dateAdapter={AdapterDayjs}>
                <DemoContainer components={["DatePicker"]}>
                  <DatePicker
                    sx={{ width: 225 }}
                    label="Expiration date"
                    value={expirationDate}
                    onChange={onChangeExpirationDate}
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
export default PollForm;
