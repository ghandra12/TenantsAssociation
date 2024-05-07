import * as React from "react";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Button from "@mui/material/Button";
import Modal from "@mui/material/Modal";
import AnnouncementForm from "../Announcement/AnnouncementForm";

const AdminHomepage = () => {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const onNavigateToAddInvoiceForm = () => {
    navigate("/addinvoiceform");
  };
  const onNavigateToAddUserForm = () => {
    navigate("/adduserform");
  };

  return (
    <Box sx={{ flexGrow: 1, mt: 10, ml: 4 }}>
      <Grid container spacing={20}>
        <Grid item xs={8}>
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell sx={{ fontSize: "1.2rem", fontWeight: "bold" }}>
                    Messages from tenants
                  </TableCell>
                </TableRow>
              </TableHead>
              <TableBody></TableBody>
            </Table>
          </TableContainer>
        </Grid>
        <Grid item xs={4}>
          <Grid
            container
            direction="column"
            justifyContent="center"
            columns={{ xs: 4, md: 12 }}
            spacing={2}
          >
            <Grid item>
              <Button
                variant="contained"
                color="secondary"
                onClick={onNavigateToAddInvoiceForm}
              >
                Add Invoices
              </Button>
            </Grid>
            <Grid item>
              <Button
                variant="contained"
                color="secondary"
                onClick={handleOpen}
              >
                Add Announcement
              </Button>
              <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
              >
                <AnnouncementForm handleClose={handleClose} />
              </Modal>
            </Grid>
            <Grid item>
              <Button variant="contained" color="secondary">
                Add poll
              </Button>
            </Grid>
            <Grid item>
              <Button color="secondary" variant="contained">
                Add services
              </Button>
            </Grid>
            <Grid item>
              <Button color="secondary" variant="contained">
                Send messages
              </Button>
            </Grid>
            <Grid item>
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
