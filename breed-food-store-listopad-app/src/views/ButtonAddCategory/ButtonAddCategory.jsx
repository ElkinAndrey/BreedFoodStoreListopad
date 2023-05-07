import React from "react";
import classes from "./ButtonAddCategory.module.css";

const ButtonAddCategory = () => {
  return (
    <div>
      <button className={classes.button}>
        <img className={classes.image} src="./images/category.png" alt="" />
        <div className={classes.text}>Добавить категорию</div>
      </button>
    </div>
  );
};

export default ButtonAddCategory;
