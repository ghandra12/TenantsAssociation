import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import OutlinedInput from "@mui/material/OutlinedInput";
import API from "../Services/api";
import InputAdornment from "@mui/material/InputAdornment";
import { DemoContainer } from "@mui/x-date-pickers/internals/demo";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";

const InvoiceForm = () => {
  const [invoiceNumber, setInvoiceNumber] = useState();
  const [sum, setSum] = useState();
  const [description, setDescription] = useState();
  const [dueDate, setDueDate] = useState();
  const [releaseDate, setReleaseDate] = useState();
  const [tenant, setTenant] = useState(null);
  const [tenants, setTenants] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    API.get("User/getalltenants").then((response) => {
      setTenants(response.data);
    });
  }, []);
  const onChangeTenantHandler = (event) => {
    setTenant(event.target.value);
  };
  const onChangeInvoiceNumberHandler = (event) => {
    setInvoiceNumber(event.target.value);
  };
  const onChangeDescriptionHandler = (event) => {
    setDescription(event.target.value);
  };
  const onChangeSumHandler = (event) => {
    setSum(event.target.value);
  };
  const onChangeDueDateHandler = (event) => {
    setDueDate(event);
  };
  const onChangeReleaseDateHandler = (event) => {
    setReleaseDate(event);
  };
  const onSubmitHandler = (event) => {
    event.preventDefault();

    API.post("Invoice/addinvoice", {
      invoiceNumber: invoiceNumber,
      sum: sum,
      dueDate: dueDate,
      releaseDate: releaseDate,
      description: description,
      userId: tenant,
    }).then((response) => {
      navigate("/adminhome");
    });
  };

  return (
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
              label="Invoice number"
              variant="outlined"
              value={invoiceNumber}
              onChange={onChangeInvoiceNumberHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="outlined-basic"
              label="Description"
              variant="outlined"
              value={description}
              onChange={onChangeDescriptionHandler}
            />
          </Grid>
          <Grid item xs={6}>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DemoContainer components={["DatePicker"]}>
                <DatePicker
                  sx={{ width: 225 }}
                  label="Release date"
                  value={releaseDate}
                  onChange={onChangeReleaseDateHandler}
                />
              </DemoContainer>
            </LocalizationProvider>
          </Grid>
          <Grid item xs={6}>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DemoContainer components={["DatePicker"]}>
                <DatePicker
                  sx={{ width: 225 }}
                  label="Due date"
                  value={dueDate}
                  onChange={onChangeDueDateHandler}
                />
              </DemoContainer>
            </LocalizationProvider>
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={{ maxWidth: 225 }}>
              <InputLabel htmlFor="outlined-adornment-amount">
                Amount
              </InputLabel>
              <OutlinedInput
                id="outlined-adornment-amount"
                startAdornment={
                  <InputAdornment position="start">$</InputAdornment>
                }
                label="Amount"
                value={sum}
                onChange={onChangeSumHandler}
              />
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={{ minWidth: 225 }}>
              <InputLabel id="demo-simple-select-label">Tenant</InputLabel>
              <Select
                fullWidth
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={tenant}
                label="Age"
                onChange={onChangeTenantHandler}
              >
                {tenants.map((tenant) => {
                  return <MenuItem value={tenant.id}>{tenant.name}</MenuItem>;
                })}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <Button
              color="secondary"
              type="submit"
              onClick={onSubmitHandler}
              variant="contained"
            >
              Add invoice
            </Button>
          </Grid>
        </Grid>
      </Box>
    </form>
  );
};
export default InvoiceForm;
