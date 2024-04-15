import "./App.css";
//import LoginPage from "./LoginPage/LoginPage";
import { BrowserRouter } from "react-router-dom";
import MenuBar from "./MenuBar/MenuBar";
import { createTheme, ThemeProvider } from "@mui/material/styles";
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
  return (
    <ThemeProvider theme={theme}>
      <BrowserRouter>
        <MenuBar />
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;
