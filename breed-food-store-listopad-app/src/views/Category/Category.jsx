import React from "react";
import classes from "./Category.module.css";

const Category = ({ name, filePath, onClickDelete }) => {
  return (
    <div>
      <div className={classes.category}>
        <div className={classes.category_content}>
          <div className={classes.logo}>{name}</div>
          <img className={classes.image} src={filePath} alt="" />
          <div className={classes.buttons}>
            <button className={classes.button_update}>
              <div>Изменить</div>
            </button>
            <button className={classes.button_delete} onClick={onClickDelete}>
              <img src="./images/trash.png  " alt="" />
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Category;
