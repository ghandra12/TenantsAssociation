import React from "react";
import AdminCard from "./AdminCard";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
const admins = [
  { description: "Adminul de la Complex 1", name: "Admin 1" },
  { description: "Adminul de la Complex 2", name: "Admin 2" },
  { description: "Adminul de la Complex 3", name: "Admin 3" },
];

const NeedHelp = () => {
  return (
    <Box
      display="flex"
      alignItems="center"
      justifyContent="center"
      sx={{ mt: 3, ml: 15 }}
    >
      <Grid container spacing={0}>
        {admins.map((admin) => (
          <Grid item xs={4} key={admin.id}>
            <AdminCard description={admin.description} name={admin.name} />
          </Grid>
        ))}
      </Grid>
    </Box>
  );
};
export default NeedHelp;
