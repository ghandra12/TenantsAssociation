import "./App.css";
import AdminHomepage from "./AdminHomepage/AdminHomepage";
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
     <AdminHomepage></AdminHomepage>
    </ThemeProvider>
  );
}

export default App;
