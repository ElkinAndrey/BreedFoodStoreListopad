import React from "react";
import classes from "./Category.module.css";
import { Link } from 'react-router-dom';

const Category = ({ name, filePath, onClickDelete }) => {
  return (
    <div>
      <div className={classes.category}>
        <div className={classes.category_content}>
          <div className={classes.logo}>{name}</div>
          <img className={classes.image} src={filePath} alt="" />
          <div className={classes.buttons}>
            <Link to={`/изменить_категорию/${name}`} className={classes.button_update}>
              Изменить
            </Link>
            <button className={classes.button_delete} onClick={onClickDelete}>
              <img src="/images/trash.png  " alt="" />
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Category;
