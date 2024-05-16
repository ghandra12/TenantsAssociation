import * as React from "react";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import NewReleasesIcon from "@mui/icons-material/NewReleases";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Button from "@mui/material/Button";
import Modal from "@mui/material/Modal";
import AnnouncementForm from "../Announcement/AnnouncementForm";
import PollForm from "../Poll/PollForm";
import API from "../Services/api";
import Typography from "@mui/material/Typography";
const AdminHomepage = () => {
  const navigate = useNavigate();
  const [openPoll, setOpenPoll] = useState(false);
  const [openAnnounce, setOpenAnnounce] = useState(false);
  const [messages, setMessages] = useState([]);

  const handleOpenPoll = () => setOpenPoll(true);
  const handleOpenAnnounce = () => setOpenAnnounce(true);
  const handleClosePoll = () => setOpenPoll(false);
  const handleCloseAnnounce = () => setOpenAnnounce(false);
  const onNavigateToAddInvoiceForm = () => {
    navigate("/addinvoiceform");
  };
  const onNavigateToAddUserForm = () => {
    navigate("/adduserform");
  };
  useEffect(() => {
    API.get("/Message/getallmessages").then((response) => {
      setMessages(response.data);
    });
  }, []);
  const onChangeStatus = (messageId) => {
    API.put(`Message/readmessage/${messageId}`).then(() => {
      var index = messages.findIndex((m) => m.id === messageId);
      messages[index].isRead = true;
      setMessages([...messages]);
    });
  };
  const onDeleteMessage = (messageId) => {
    API.put(`Message/deletemessage/${messageId}`).then(() => {
      var index = messages.findIndex((m) => m.id === messageId);
      messages.splice(index, 1);
      setMessages([...messages]);
    });
  };
  return (
    <Box sx={{ flexGrow: 1, mt: 10, ml: 4 }}>
      <Grid container spacing={20}>
        <Grid item xs={8}>
          <Grid xs={12} mb={3}>
            <Typography variant="h5" color="primary">
              Messages from tenants
            </Typography>
          </Grid>
          {messages.length === 0 && (
            <Typography
              variant="h6"
              color="secondary"
              border={1}
              paddingBlock={4}
              paddingLeft={2}
            >
              ...you have no messages yet!
            </Typography>
          )}
          <div>
            {messages.map((message) => {
              return (
                <Accordion key={message}>
                  <AccordionSummary
                    expandIcon={<ExpandMoreIcon />}
                    aria-controls="panel2-content"
                    id="panel2-header"
                  >
                    {message.isRead === false && (
                      <Grid>
                        <NewReleasesIcon color="error" />
                      </Grid>
                    )}

                    <Grid>
                      <Typography>{message.firstName}</Typography>
                    </Grid>
                    <Grid ml={1}>
                      <Typography>{message.lastName}</Typography>
                    </Grid>
                    <Grid ml={1}>
                      <Typography color="primary">
                        <b>Issue date:</b> {message.creationDate.split("T")[0]}
                      </Typography>
                    </Grid>
                    <Grid item xs={6}>
                      {/* <i>
                        <Typography color="secondary">
                          {announce.date.split("T")[0]}
                        </Typography>
                      </i> */}
                    </Grid>
                  </AccordionSummary>
                  <AccordionDetails>
                    <Grid item xs={12}>
                      <Typography>
                        <b>email:</b> {message.userEmail}
                      </Typography>
                    </Grid>
                    <Grid item xs={12}>
                      <Typography>{message.description}</Typography>
                    </Grid>
                    <Grid item xs={4} mb={2} mt={2}>
                      {message.isRead === false && (
                        <Button
                          variant="contained"
                          color="secondary"
                          onClick={() => onChangeStatus(message.id)}
                          size="small"
                        >
                          Mark as read
                        </Button>
                      )}
                    </Grid>
                    <Grid item xs={4} mb={2}>
                      {" "}
                      <Button
                        variant="contained"
                        color="error"
                        onClick={() => onDeleteMessage(message.id)}
                        size="small"
                      >
                        {" "}
                        Delete
                      </Button>
                    </Grid>
                  </AccordionDetails>
                </Accordion>
              );
            })}
          </div>
        </Grid>
        <Grid item xs={4} mt={5}>
          <Grid
            container
            direction="column"
            justifyContent="center"
            columns={{ xs: 4, md: 12 }}
            spacing={2}
          >
            <Grid item xs={6}>
              <Button
                variant="contained"
                color="secondary"
                onClick={onNavigateToAddInvoiceForm}
              >
                Add Invoices
              </Button>
            </Grid>
            <Grid item xs={6}>
              <Button
                variant="contained"
                color="secondary"
                onClick={handleOpenAnnounce}
              >
                Add Announcement
              </Button>
              <Modal
                open={openAnnounce}
                onClose={handleCloseAnnounce}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
              >
                <AnnouncementForm handleClose={handleCloseAnnounce} />
              </Modal>
            </Grid>
            <Grid item xs={6}>
              <Button
                variant="contained"
                color="secondary"
                onClick={handleOpenPoll}
              >
                Add poll
              </Button>
              <Modal
                open={openPoll}
                onClose={handleClosePoll}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
              >
                <PollForm handleClose={handleClosePoll} />
              </Modal>
            </Grid>

            <Grid item xs={6}>
              <Button
                color="secondary"
                variant="contained"
                onClick={onNavigateToAddUserForm}
              >
                Create user
              </Button>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Box>
  );
};
export default AdminHomepage;
