import React, { useContext } from "react";
import { Route, Routes } from "react-router-dom";
import { routes } from "./../routes";
import Notifications from "../../components/layout/Notifications/Notifications";
import { Context } from "../../context/context";

const AppRouter = () => {
  const { notifications, setNotifications } = useContext(Context);

  return (
    <div>
      <Notifications notifications={notifications} />
      <Routes path="/">
        {routes.map((rout) => (
          <Route
            exact={rout.exact}
            path={rout.path}
            element={rout.element}
            key={rout.path}
          ></Route>
        ))}
      </Routes>
    </div>
  );
};

export default AppRouter;
