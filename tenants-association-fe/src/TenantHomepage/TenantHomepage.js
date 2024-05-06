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
//import Button from "@mui/material/Button";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import Divider from "@mui/material/Divider";

const TenantHomepage = () => {
  const { user } = useContext(UserContext);
  const [invoices, setInvoices] = useState([]);
  const [announcements, setAnnouncements] = useState([]);
  useEffect(() => {
    if (user !== null) {
      API.get(`Invoice/getunpaidinvoices/${user}`).then((response) => {
        setInvoices(response.data);
      });

      API.get("Announcement/getunexpiredannouncements").then((response) => {
        setAnnouncements(response.data);
      });
    }
  }, [user]);

  return (
    <Box sx={{ flexGrow: 1, mt: 7 }}>
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
                    <TableCell align="right">{invoice.dueDate}</TableCell>
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
        alignItems="center"
        spacing={4}
        sx={{ mt: 7 }}
      >
        <Grid item>
          <FormControl>
            <FormLabel id="demo-radio-buttons-group-label">
              La ce ora sa vina deratizarea?
            </FormLabel>
            <RadioGroup
              aria-labelledby="demo-radio-buttons-group-label"
              defaultValue="female"
              name="radio-buttons-group"
            >
              <FormControlLabel
                value="female"
                control={<Radio />}
                label="8:30"
              />
              <FormControlLabel value="male" control={<Radio />} label="9:00" />
              <FormControlLabel
                value="other"
                control={<Radio />}
                label="9:30"
              />
            </RadioGroup>
          </FormControl>
        </Grid>
      </Grid>
    </Box>
  );
};

export default TenantHomepage;
