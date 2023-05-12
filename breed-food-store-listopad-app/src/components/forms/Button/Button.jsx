import React from "react";
import classes from "./Button.module.css";

const Button = ({ children, onClick, className, disabled, ...props }) => {
  return (
    <button
      disabled={disabled}
      onClick={onClick}
      className={classes.button + " " + className}
      {...props}
    >
      {children}
    </button>
  );
};

export default Button;
