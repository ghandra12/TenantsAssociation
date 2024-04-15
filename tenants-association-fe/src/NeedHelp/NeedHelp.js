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
    <Box sx={{ flexgrow: 1, ml: 10 }}>
      <Grid
        container
        direction="row"
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
        <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
          {admins.map((admin) => (
            <Grid item xs={3} key={admin.id}>
              <AdminCard description={admin.description} name={admin.name} />
            </Grid>
          ))}
        </Grid>
      </Grid>
    </Box>
  );
};
export default NeedHelp;
