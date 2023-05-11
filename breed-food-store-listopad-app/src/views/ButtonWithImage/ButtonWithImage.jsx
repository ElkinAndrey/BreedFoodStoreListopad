import React from "react";
import classes from "./ButtonWithImage.module.css";
import { Link } from "react-router-dom";

const ButtonWithImage = ({text, imagePath, to, style}) => {
  return (
    <div style={style}>
      <Link to={to} className={classes.button}>
        <img className={classes.image} src={imagePath} alt="" />
        <div className={classes.text}>{text}</div>
      </Link>
    </div>
  );
};

export default ButtonWithImage;
