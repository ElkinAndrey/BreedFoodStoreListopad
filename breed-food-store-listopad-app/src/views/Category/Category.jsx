import React from "react";
import classes from "./Category.module.css";
import { Link } from "react-router-dom";
import Service from "./../../api/Service";

const Category = ({ category, onClickDelete }) => {
  return (
    <div>
      <div className={classes.category}>
        <div className={classes.category_content}>
          <div className={classes.logo}>{category.name}</div>
          <img
            className={classes.image}
            src={Service.fullFilePath(category.filePath)}
            alt=""
          />
          <div className={classes.buttons}>
            <Link
              to={`/изменить_категорию/${category.name.replaceAll(" ", "_")}`}
              className={classes.button_update}
            >
              Изменить
            </Link>
            <button className={classes.button_delete} onClick={onClickDelete}>
              <img src="/images/trash.png" alt="" />
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Category;
