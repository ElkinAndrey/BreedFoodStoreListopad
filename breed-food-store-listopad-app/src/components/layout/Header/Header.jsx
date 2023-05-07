import React from "react";
import classes from "./Header.module.css";

const Header = ({ children }) => {
  return (
    <div className={classes.body}>
      <div className={classes.content}>
        <div className={classes.logo}>
          <img src="./images/logo.png" alt="" draggable="false" />
          <div>Листопад</div>
        </div>
        <div className={classes.children}>{children}</div>
      </div>
    </div>
  );
};

export default Header;
