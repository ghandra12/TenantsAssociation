import React, { useContext, useState } from "react";
import { useEffect } from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import API from "../Services/api";
import FormControl from "@mui/material/FormControl";
import InputLabel from "@mui/material/InputLabel";
import OutlinedInput from "@mui/material/OutlinedInput";
import InputAdornment from "@mui/material/InputAdornment";
import Modal from "@mui/material/Modal";
import UserContext from "../Services/UserContext";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 200,
  height: 200,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};
const Invoices = () => {
  const { user } = useContext(UserContext);
  const [invoices, setInvoices] = useState([]);
  const [openPayment, setOpenPayment] = useState(false);
  const [sum, setSum] = useState(0);
  const handleOpenPayment = () => setOpenPayment(true);
  const handleClosePayment = () => setOpenPayment(false);
  useEffect(() => {
    if (user !== null) {
      API.get(`Invoice/${user}`).then((response) => {
        setInvoices(response.data);
      });
    }
  }, [user]);
  const onAddPayment = (invoiceId) => {
    API.post(`Invoice/addpayment/${invoiceId}`, sum, {
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then(() => {
        var index = invoices.findIndex((i) => i.id === invoiceId);
        invoices[index].remaining -= sum;
        invoices[index].isPaid = invoices[index].remaining === 0 ? true : false;
        setInvoices([...invoices]);
        handleClosePayment();
      })
      .catch((error) => {
        alert(error.response.data);
        handleClosePayment();
      });
  };

  const onChangeSumHandler = (event) => {
    setSum(event.target.value);
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
        {invoices.length === 0 && (
          <Typography
            variant="h5"
            color="secondary"
            paddingBlock={6}
            paddingInline={6}
          >
            Currently you don't have any invoices!
          </Typography>
        )}
        {invoices.length !== 0 && (
          <TableContainer>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell align="center">Invoice number</TableCell>
                  <TableCell align="center">Description</TableCell>
                  <TableCell align="center">Release Date</TableCell>
                  <TableCell align="center">Due date</TableCell>
                  <TableCell align="center">Price</TableCell>
                  <TableCell align="center">Remaining</TableCell>
                  <TableCell align="center">Status</TableCell>
                  <TableCell align="center" />
                </TableRow>
              </TableHead>
              <TableBody>
                {invoices.map((i) => (
                  <TableRow
                    key={i.id}
                    sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                  >
                    <TableCell align="center" component="th" scope="row">
                      {i.invoiceNumber}
                    </TableCell>
                    <TableCell align="center">{i.description}</TableCell>
                    <TableCell align="center">
                      {i.releaseDate.split("T")[0]}
                    </TableCell>
                    <TableCell align="center">
                      {" "}
                      {i.dueDate.split("T")[0]}
                    </TableCell>
                    <TableCell align="center">{i.sum}</TableCell>
                    <TableCell align="center">{i.remaining}</TableCell>
                    <TableCell align="center">
                      {i.isPaid === true ? "Paid" : "Unpaid"}
                    </TableCell>
                    <TableCell align="center">
                      {i.isPaid === false && (
                        <>
                          <Button
                            variant="contained"
                            size="small"
                            onClick={handleOpenPayment}
                            color="primary"
                          >
                            Pay!
                          </Button>
                          <Modal
                            open={openPayment}
                            onClose={handleClosePayment}
                            aria-labelledby="modal-modal-title"
                            aria-describedby="modal-modal-description"
                          >
                            <Box sx={style}>
                              <Grid container spacing={3}>
                                <Grid item xs={12}>
                                  <Typography variant="h7" color="secondary">
                                    How much do you want to pay?
                                  </Typography>
                                </Grid>
                                <Grid item xs={12}>
                                  <FormControl sx={{ maxWidth: 225 }}>
                                    <InputLabel
                                      mb={10}
                                      htmlFor="outlined-adornment-amount"
                                    >
                                      Amount
                                    </InputLabel>
                                    <OutlinedInput
                                      id="outlined-adornment-amount"
                                      startAdornment={
                                        <InputAdornment position="start">
                                          $
                                        </InputAdornment>
                                      }
                                      label="Amount"
                                      value={sum}
                                      onChange={onChangeSumHandler}
                                    />
                                  </FormControl>
                                </Grid>
                                <Grid item xs={12}>
                                  <Button
                                    color="secondary"
                                    onClick={() => onAddPayment(i.id)}
                                    variant="contained"
                                  >
                                    Add payment
                                  </Button>
                                </Grid>
                              </Grid>
                            </Box>
                          </Modal>
                        </>
                      )}
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        )}
      </Paper>
    </Box>
  );
};
export default Invoices;
