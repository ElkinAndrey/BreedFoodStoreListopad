import React from "react";
import classes from "./Center.module.css";

const Center = ({ children, className }) => {
  return (
    <div className={classes.first}>
      <div className={classes.second}>
        <div className={classes.third + " " + className}>{children}</div>
      </div>
    </div>
  );
};

export default Center;
