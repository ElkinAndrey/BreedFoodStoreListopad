import React from "react";
import classes from "./Restore.module.css";

const Restore = ({ logo, text, restoreAction, backAction }) => {
  return (
    <div>
      <div className={classes.logo}>{logo}</div>
      <div className={classes.text}>{text}</div>
      <div className={classes.buttons}>
        <div>
          <button
            className={classes.button + " " + classes.restore}
            onClick={restoreAction}
          >
            Востановить
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

export default Restore;
