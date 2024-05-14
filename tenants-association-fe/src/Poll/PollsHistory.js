import React, { useState } from "react";
import { useEffect } from "react";
import Paper from "@mui/material/Paper";
import API from "../Services/api";
import Box from "@mui/material/Box";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import Typography from "@mui/material/Typography";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { PieChart } from "@mui/x-charts";

const PollsHistory = () => {
  const [polls, setPolls] = useState();
  useEffect(() => {
    API.get(`Poll/getallpolls`).then((response) => {
      setPolls(response.data);
    });
  }, []);

  return (
    <Box
      sx={{
        flexGrow: 1,
        mt: 7,
        marginRight: 20,
        marginLeft: 20,
        marginBottom: 20,
      }}
    >
      <Typography
        sx={{ flex: "1 1 100%" }}
        variant="h6"
        id="tableTitle"
        component="div"
        color="secondary"
        mb={2}
      >
        Here you can see all the polls and their responses.
      </Typography>
      <Paper elevation={24}>
        <div>
          {polls?.map((poll) => {
            return (
              <Accordion>
                <AccordionSummary
                  expandIcon={<ExpandMoreIcon />}
                  aria-controls="panel1-content"
                  id="panel1-header"
                >
                  <Typography color="primary">{poll.question}</Typography>
                </AccordionSummary>
                <AccordionDetails>
                  <PieChart
                    series={[
                      {
                        data: poll?.answers?.map((a) => {
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
                </AccordionDetails>
              </Accordion>
            );
          })}
        </div>
      </Paper>
    </Box>
  );
};
export default PollsHistory;
