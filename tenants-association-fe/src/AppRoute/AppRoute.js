import LoginPage from "../LoginPage/LoginPage";
import { Navigate, Routes, Route } from "react-router-dom";
import NeedHelp from "../NeedHelp/NeedHelp";

const ProtectedRoute = ({ redirectPath = "/login", children }) => {
  if (!localStorage.getItem("authenticated")) {
    return <Navigate to={redirectPath} replace />;
  }

  return children;
};

function AppRoutes({ loggedIn, setLoggedIn }) {
  return (
    <Routes>
      {/* <Route
        exact
        path="/"
        element={
          <ProtectedRoute redirectPath="/login">
            <HomePage />
          </ProtectedRoute>
        }
      /> */}
      <Route
        exact
        path="/login"
        element={
          loggedIn ? (
            <Navigate to={"/"} replace />
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
