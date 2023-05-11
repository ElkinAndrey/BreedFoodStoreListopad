import React from "react";
import classes from "./ButtonAddCategory.module.css";
import { Link } from "react-router-dom";

const ButtonAddCategory = () => {
  return (
    <div>
      <Link to="/добавить_категорию" className={classes.button}>
        <img className={classes.image} src="/images/category.png" alt="" />
        <div className={classes.text}>Добавить категорию</div>
      </Link>
    </div>
  );
};

export default ButtonAddCategory;
