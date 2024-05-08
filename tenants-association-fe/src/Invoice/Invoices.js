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
import UserContext from "../Services/UserContext";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";
const Invoices = () => {
  const { user } = useContext(UserContext);
  const [invoices, setInvoices] = useState([]);
  useEffect(() => {
    if (user !== null) {
      API.get(`Invoice/${user}`).then((response) => {
        setInvoices(response.data);
      });
    }
  }, [user]);
  const onChangeStatus = (invoiceId) => {
    API.put(`Invoice/payinvoice/${invoiceId}`).then(() => {
      var index = invoices.findIndex((i) => i.id === invoiceId);
      invoices[index].isPaid = true;
      setInvoices(invoices);
    });
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
        <TableContainer>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell align="center">Invoice number</TableCell>
                <TableCell align="center">Description</TableCell>
                <TableCell align="center">Release Date</TableCell>
                <TableCell align="center">Due date</TableCell>
                <TableCell align="center">Price</TableCell>
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
                  <TableCell align="center">{i.releaseDate}</TableCell>
                  <TableCell align="center">{i.dueDate}</TableCell>
                  <TableCell align="center">{i.sum}</TableCell>
                  <TableCell align="center">
                    {i.isPaid === true ? "Paid" : "Unpaid"}
                  </TableCell>
                  <TableCell align="center">
                    {i.isPaid === false && (
                      <Button
                        variant="outlined"
                        size="small"
                        onClick={() => onChangeStatus(i.id)}
                      >
                        Pay!
                      </Button>
                    )}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
    </Box>
  );
};
export default Invoices;
