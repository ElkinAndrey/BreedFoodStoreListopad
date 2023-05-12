import React, { useState } from "react";
import classes from "./Notification.module.css";

const Notification = ({ borderColor = "var(--button)", children }) => {
  const [close, setClose] = useState(false);

  return (
    <div
      style={{ border: `3px solid ${borderColor}` }}
      className={close ? classes.close : classes.notification}
    >
      {children}
      <button className={classes.closeButton} onClick={() => setClose(true)}>
        <div className={classes.closeButtonText}>X</div>
      </button>
    </div>
  );
};

export default Notification;
