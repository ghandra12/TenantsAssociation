import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import API from "../Services/api";

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
const PollForm = (props) => {
  const [question, setQuestion] = useState();
  const [answers, setAnswers] = useState(["", ""]);
  const onChangeQuestionHandler = (event) => {
    setQuestion(event.target.value);
  };
  const handleAnswerChange = (e, index) => {
    const newAnswers = [...answers];
    newAnswers[index] = e.target.value;
    setAnswers(newAnswers);
  };
  const handleAddAnswer = () => {
    setAnswers([...answers, ""]);
  };
  const onSubmitHandler = (event) => {
    event.preventDefault();

    API.post("Poll/addpoll", {
      question: question,
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
                id="outlined-basic"
                label="Question"
                variant="outlined"
                value={question}
                onChange={onChangeQuestionHandler}
                size="small"
              />
            </Grid>
            <Grid item xs={6}>
              {answers.map((answer, index) => (
                <Grid item xs={6} mt={2}>
                  <TextField
                    id="outlined-basic"
                    label="Variant"
                    variant="outlined"
                    key={index}
                    type="text"
                    value={answer}
                    onChange={(e) => handleAnswerChange(e, index)}
                  />
                </Grid>
              ))}

              <Button
                color="secondary"
                variant="contained"
                onClick={handleAddAnswer}
              >
                Add Answer
              </Button>
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
