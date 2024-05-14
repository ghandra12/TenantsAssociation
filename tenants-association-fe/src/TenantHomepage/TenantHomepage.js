import React, { useContext, useState } from "react";
import { useEffect } from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import Radio from "@mui/material/Radio";
import RadioGroup from "@mui/material/RadioGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import API from "../Services/api";
import UserContext from "../Services/UserContext";
import Button from "@mui/material/Button";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { PieChart } from "@mui/x-charts";
const TenantHomepage = () => {
  const { user } = useContext(UserContext);
  const [invoices, setInvoices] = useState([]);
  const [announcements, setAnnouncements] = useState([]);
  const [question, setQuestion] = useState("");
  const [answers, setAnswers] = useState([]);
  const [expirationDate, setExpirationDate] = useState("");
  const [pollResponse, setPollResponse] = useState();

  useEffect(() => {
    if (user !== null) {
      API.get(`Invoice/getunpaidinvoices/${user}`).then((response) => {
        setInvoices(response.data);
      });
      API.get("Poll/getpoll").then((response) => {
        setQuestion(response.data.question);
        setAnswers(response.data.answers);
        setExpirationDate(response.data.expirationDate);
      });

      API.get("Announcement/getunexpiredannouncements").then((response) => {
        setAnnouncements(response.data);
      });
    }
  }, [user]);

  const onChangeResponseHandler = (event) => {
    setPollResponse(parseInt(event.target.value));
  };
  const onSubmitPollHandler = () => {
    API.post(
      "Poll/addpollanswer",
      answers.find((a) => a.id === pollResponse)
    ).then((response) => {
      API.get("Poll/getpoll").then((response) => {
        setQuestion(response.data.question);
        setAnswers(response.data.answers);
        setExpirationDate(response.data.expirationDate);
      });
      alert("Your answer was registered");
    });
  };

  return (
    <Box sx={{ flexGrow: 1, mt: 7, marginRight: 10 }}>
      <Grid
        container
        direction="row"
        justifyContent="center"
        alignItems="center"
        spacing={4}
      >
        <Grid item xs={6}>
          <Typography
            sx={{ flex: "1 1 100%" }}
            variant="h5"
            id="tableTitle"
            component="div"
            color="primary"
          >
            Announcements:
          </Typography>
          <div>
            {announcements.map((announce) => {
              return (
                <Accordion>
                  <AccordionSummary
                    expandIcon={<ExpandMoreIcon />}
                    aria-controls="panel2-content"
                    id="panel2-header"
                  >
                    <Grid item xs={6}>
                      <Typography>{announce.title}</Typography>
                    </Grid>
                    <Grid item xs={6}>
                      <i>
                        <Typography color="secondary">
                          {announce.date.split("T")[0]}
                        </Typography>
                      </i>
                    </Grid>
                  </AccordionSummary>
                  <AccordionDetails>
                    <Typography>{announce.content}</Typography>
                  </AccordionDetails>
                </Accordion>
              );
            })}
          </div>
        </Grid>
        <Grid item>
          <Typography
            sx={{ flex: "1 1 100%" }}
            variant="h5"
            id="tableTitle"
            component="div"
            color="primary"
          >
            Unpaid invoices:
          </Typography>
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableBody>
                {invoices.map((invoice) => (
                  <TableRow
                    key={invoice.id}
                    sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                  >
                    <TableCell component="th" scope="row">
                      {invoice.description}
                    </TableCell>
                    <TableCell align="right">
                      {invoice.dueDate.split("T")[0]}
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
      </Grid>
      <Grid
        container
        direction="row"
        justifyContent="center"
        alignItems="right"
        spacing={4}
        sx={{ mt: 7, mb: 10, ml: 3 }}
        paddingBottom={2}
        border={1}
        borderColor="green"
      >
        <Grid item xs={6}>
          <Typography
            sx={{ flex: "1 1 100%" }}
            variant="h5"
            component="div"
            mb={2}
            color="primary"
          >
            Active poll:
          </Typography>
          {question !== undefined && (
            <Typography
              sx={{ flex: "1 1 100%" }}
              id="tableTitle"
              component="div"
              mb={2}
              color="secondary"
            >
              You can send your answer until {expirationDate?.split("T")[0]}.
            </Typography>
          )}
          <FormControl>
            <FormLabel id="demo-radio-buttons-group-label">
              {question !== undefined
                ? question
                : "There is no poll available."}
            </FormLabel>
            <RadioGroup
              aria-labelledby="demo-radio-buttons-group-label"
              name="radio-buttons-group"
            >
              {answers?.map((answer) => {
                return (
                  <FormControlLabel
                    value={answer.answer}
                    key={answer.id}
                    control={
                      <Radio
                        checked={pollResponse === answer.id}
                        onChange={onChangeResponseHandler}
                        value={answer.id}
                      />
                    }
                    label={answer.answer}
                  />
                );
              })}
            </RadioGroup>
            {question !== undefined && (
              <Button
                color="secondary"
                variant="contained"
                size="small"
                onClick={onSubmitPollHandler}
              >
                Send answer
              </Button>
            )}
          </FormControl>
        </Grid>

        <Grid item xs={6}>
          {question !== undefined && (
            <PieChart
              series={[
                {
                  data: answers.map((a) => {
                    return {
                      id: a.id,
                      value: a.count,
                      label: a.answer,
                    };
                  }),
                },
              ]}
              width={400}
              height={200}
            />
          )}
        </Grid>
      </Grid>
    </Box>
  );
};

export default TenantHomepage;
