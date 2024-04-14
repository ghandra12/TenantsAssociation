import * as React from "react";
import "./AdminCard.css";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
//import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";

const AdminCard = (props) => {
  return (
    <Card sx={{ maxWidth: 345, height: 330 }}>
      <CardContent>
        <Typography gutterBottom variant="h5" component="div">
          {props.name}
        </Typography>
        <Typography
          sx={{
            overflow: "hidden",
            textOverflow: "ellipsis",
            display: "-webkit-box",
            WebkitLineClamp: "3",
            WebkitBoxOrient: "vertical",
          }}
          variant="body2"
          color="text.secondary"
        >
          {props.description}
        </Typography>
      </CardContent>
    </Card>
  );
};
export default AdminCard;
