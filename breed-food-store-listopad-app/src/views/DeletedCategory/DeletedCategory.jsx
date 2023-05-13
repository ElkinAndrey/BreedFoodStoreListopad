import React from "react";
import GetDate from "./../../utils/GetDate";
import classes from "./DeletedCategory.module.css";
import Service from "./../../api/Service";
import { Link } from "react-router-dom";

const DeletedCategory = ({ category, onDelete, onRestore }) => {
  return (
    <div className={classes.body}>
      <Link
        to={`/изменить_категорию/${category.name.replaceAll(" ", "_")}`}
        className={classes.text}
      >
        <div className={classes.name}>{category.name}</div>
        <div className={classes.date}>
          Дата удаления {GetDate.DateToString(category.deletionDate)}
        </div>
      </Link>
      <Link to={`/изменить_категорию/${category.name.replaceAll(" ", "_")}`}>
        <img
          className={classes.image + " skeletonImage"}
          src={Service.fullFilePath(category.filePath)}
          alt=""
        />
      </Link>
      <div className={classes.buttons}>
        <button className={classes.set + " " + classes.button} onClick={onRestore}>
          Вернуть
        </button>
        <Link
          to={`/изменить_категорию/${category.name.replaceAll(" ", "_")}`}
          className={classes.buttonlink}
        ></Link>
        <button className={classes.del + " " + classes.button} onClick={onDelete}>
          Удалить
        </button>
      </div>
    </div>
  );
};

export default DeletedCategory;
