import React from "react";
import classes from "./Header.module.css";
import { Link } from "react-router-dom";

const Header = ({ children }) => {
  return (
    <div className={classes.body}>
      <div className={classes.content}>
        <Link to="/" className={classes.logo}>
          <img src="/images/logo.png" alt="" />
          <div>Листопад</div>
        </Link>
        <div className={classes.children}>{children}</div>
      </div>
    </div>
  );
};

export default Header;
