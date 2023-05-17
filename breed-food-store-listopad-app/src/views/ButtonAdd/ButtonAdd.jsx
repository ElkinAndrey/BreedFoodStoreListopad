import React, { useEffect, useState } from "react";
import classes from "./ButtonAdd.module.css";
import Button from "./../../components/forms/Button/Button";
import Loader from "./../../components/forms/Loader/Loader";
import AddNotification from "./../../utils/AddNotification";
import Notification from "../../components/forms/Notification/Notification";
const ButtonAdd = ({
  text,
  loadingText,
  loading,
  error,
  onClick,
  actionsAfter,
  color,
  colorActive,
  notifications,
  setNotifications,
  successfulMessage,
  failedMessage,
}) => {
  const [subloading, setSubloading] = useState(false);
  const [isHovering, setIsHovering] = useState(false);

  const handleMouseEnter = () => {
    setIsHovering(true);
  };

  const handleMouseLeave = () => {
    setIsHovering(false);
  };

  useEffect(() => {
    if (loading && !subloading) {
      setSubloading(true);
    }

    if (subloading && !loading) {
      setSubloading(false);
      actionsAfter();
      if (Object.keys(error).length === 0 || !error) {
        AddNotification(
          <Notification borderColor={"var(--button-restore)"}>
            <div
              style={{
                fontSize: "22px",
                wordWrap: "break-word",
                wordBreak: "break-word",
              }}
            >
              {successfulMessage}
            </div>
          </Notification>,
          notifications,
          setNotifications
        );
      } else {
        AddNotification(
          <Notification borderColor={"var(--button-delete)"}>
            <div
              style={{
                fontSize: "22px",
                wordWrap: "break-word",
                wordBreak: "break-word",
              }}
            >
              {failedMessage}
            </div>
          </Notification>,
          notifications,
          setNotifications
        );
      }
    }
  }, [loading]);

  return (
    <div style={{ height: "100%" }}>
      {subloading && !loading ? (
        <Button disabled={true} className={classes.button} onClick={onClick}>
          {text}
        </Button>
      ) : (
        <div style={{ height: "100%" }}>
          {loading ? (
            <div className={classes.loading}>
              <div className={classes.loader}>
                <Loader width="35px" color={color} />
              </div>
              <div style={{ color: color }}>{loadingText}</div>
            </div>
          ) : (
            <Button
              style={{
                backgroundColor: isHovering ? colorActive : color,
              }}
              onMouseEnter={handleMouseEnter}
              onMouseLeave={handleMouseLeave}
              onClick={onClick}
            >
              {text}
            </Button>
          )}
        </div>
      )}
    </div>
  );
};

export default ButtonAdd;
