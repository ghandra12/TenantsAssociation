import LoginPage from "../LoginPage/LoginPage";
import { Navigate, Routes, Route } from "react-router-dom";
import NeedHelp from "../NeedHelp/NeedHelp";
import TenantHomepage from "../TenantHomepage/TenantHomepage";

const ProtectedRoute = ({ redirectPath = "/login", children }) => {
  if (!localStorage.getItem("authenticated")) {
    return <Navigate to={redirectPath} replace />;
  }

  return children;
};

function AppRoutes({ loggedIn, setLoggedIn }) {
  return (
    <Routes>
      <Route
        exact
        path="/tenanthome"
        element={
          <ProtectedRoute redirectPath="/">
            <TenantHomepage />
          </ProtectedRoute>
        }
      />
      <Route
        exact
        path="/"
        element={
          loggedIn ? (
            <Navigate to={"/tenanthome"} replace />
          ) : (
            <LoginPage setLoggedIn={setLoggedIn} />
          )
        }
      />
      <Route exact path="/needHelp" element={<NeedHelp></NeedHelp>} />
    </Routes>
  );
}

export default AppRoutes;
