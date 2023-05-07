import React from "react";
import classes from "./Delete.module.css";

const Delete = ({ logo, text, deleteAction, backAction }) => {
  return (
    <div>
      <div className={classes.logo}>{logo}</div>
      <div className={classes.text}>{text}</div>
      <div className={classes.buttons}>
        <div>
          <button
            className={classes.button + " " + classes.delete}
            onClick={deleteAction}
          >
            Удалить
          </button>
        </div>
        <div>
          <button
            className={classes.button + " " + classes.back}
            onClick={backAction}
          >
            Назад
          </button>
        </div>
      </div>
    </div>
  );
};

export default Delete;
