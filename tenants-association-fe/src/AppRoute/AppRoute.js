import LoginPage from "../LoginPage/LoginPage";
import { Navigate, Routes, Route } from "react-router-dom";
import NeedHelp from "../NeedHelp/NeedHelp";
import TenantHomepage from "../TenantHomepage/TenantHomepage";
import AdminHomepage from "../AdminHomepage/AdminHomepage";
const TenantProtectedRoute = ({ redirectPath = "/", children }) => {
  if (
    !localStorage.getItem("authenticated") &&
    !sessionStorage.getItem("authenticated")
  ) {
    return <Navigate to={redirectPath} replace />;
  }
  if (
    localStorage.getItem("userType") === "2" ||
    sessionStorage.getItem("userType") === "2"
  )
    return children;
  return <Navigate to={redirectPath} replace />;
};
const AdminProtectedRoute = ({ redirectPath = "/", children }) => {
  if (
    !localStorage.getItem("authenticated") &&
    !sessionStorage.getItem("authenticated")
  ) {
    return <Navigate to={redirectPath} replace />;
  }
  if (
    localStorage.getItem("userType") === "1" ||
    sessionStorage.getItem("userType") === "1"
  )
    return children;
  return <Navigate to={redirectPath} replace />;
};
function AppRoutes({ loggedIn, setLoggedIn }) {
  return (
    <Routes>
      <Route
        exact
        path="/tenanthome"
        element={
          <TenantProtectedRoute redirectPath="/">
            <TenantHomepage />
          </TenantProtectedRoute>
        }
      />
      <Route
        exact
        path="/adminhome"
        element={
          <AdminProtectedRoute redirectPath="/">
            <AdminHomepage />
          </AdminProtectedRoute>
        }
      />
      <Route
        exact
        path="/"
        element={
          loggedIn ? (
            sessionStorage.getItem("userType") === "2" ||
            localStorage.getItem("userType") === "2" ? (
              <Navigate to={"/tenanthome"} replace />
            ) : (
              <Navigate to={"/adminhome"} replace />
            )
          ) : (
            <LoginPage setLoggedIn={setLoggedIn} />
          )
        }
      />
      <Route exact path="/needHelp" element={<NeedHelp />} />
    </Routes>
  );
}

export default AppRoutes;
