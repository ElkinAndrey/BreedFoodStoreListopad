import React from "react";
import classes from "./Notifications.module.css";
const Notifications = ({ notifications }) => {
  return (
    <div className={classes.body}>
      {notifications.map((notification) => (
        <div key={notification.id}>{notification.content}</div>
      ))}
    </div>
  );
};

export default Notifications;
