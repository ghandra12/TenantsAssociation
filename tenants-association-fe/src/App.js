import "./App.css";
import TenantHomepage from "./TenantHomepage/TenantHomepage";
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
     <TenantHomepage></TenantHomepage>
    </ThemeProvider>
  );
}

export default App;
