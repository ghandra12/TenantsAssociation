import "./App.css";
import React, { useState } from "react";
//import LoginPage from "./LoginPage/LoginPage";
import { BrowserRouter } from "react-router-dom";
import MenuBar from "./MenuBar/MenuBar";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import UserContext from "./Services/UserContext";
const theme = createTheme({
  palette: {
    primary: {
      main: "#007600",
    },
    secondary: {
      main: "#8eb383",
    },
  },
});
function App() {
  const [user, setUser] = useState(null);
  return (
    <UserContext.Provider value={{ user, setUser }}>
      <ThemeProvider theme={theme}>
        <BrowserRouter>
          <MenuBar />
        </BrowserRouter>
      </ThemeProvider>
    </UserContext.Provider>
  );
}

export default App;
