import React from "react";
import classes from "./Loader.module.css";

const Loader = ({ loadingText, width = "65px", color = "var(--button)" }) => {
  return (
    <div>
      <div className={classes.body}>
        <svg
          className={classes.spinner}
          viewBox="0 0 66 66"
          width={width}
          height={width}
        >
          <circle
            className={classes.path}
            style={{
              stroke: color,
            }}
            fill="none"
            strokeWidth="6"
            strokeLinecap="round"
            cx="33"
            cy="33"
            r="30"
          ></circle>
        </svg>
        <div style={{ color: color }} className={classes.text}>
          {loadingText}
        </div>
      </div>
    </div>
  );
};

export default Loader;
