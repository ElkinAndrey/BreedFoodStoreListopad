import React from "react";
import classes from "./Button.module.css";

const Button = ({ children, onClick, style, className, disabled }) => {
  return (
    <button
      disabled={disabled}
      style={style}
      onClick={onClick}
      className={classes.button + " " + className}
    >
      {children}
    </button>
  );
};

export default Button;
