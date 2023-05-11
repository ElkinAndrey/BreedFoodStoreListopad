import React from "react";
import classes from "./Loader.module.css";

const Loader = ({ loadingText }) => {
  return (
    <div>
      <div className={classes.body}>
        <svg className={classes.spinner} viewBox="0 0 66 66">
          <circle
            className={classes.path}
            fill="none"
            strokeWidth="6"
            strokeLinecap="round"
            cx="33"
            cy="33"
            r="30"
          ></circle>
        </svg>
        <div className={classes.text}>{loadingText}</div>
      </div>
    </div>
  );
};

export default Loader;
