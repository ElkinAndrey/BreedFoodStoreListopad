import React from "react";
import classes from "./ConfirmationModalWindow.module.css";
import Modal from "./../../components/forms/Modal/Modal";
import Button from "../../components/forms/Button/Button";

const ConfirmationModalWindow = ({
  active,
  setActive,
  logo,
  text,
  borderColor,
  width,
  children,
}) => {
  return (
    <Modal
      active={active}
      setActive={setActive}
      style={{
        borderRadius: "10px",
        padding: "20px",
        width: width,
        border: `3px solid ${borderColor}`,
      }}
    >
      <div>
        <div className={classes.logo}>{logo}</div>
        <div className={classes.text}>{text}</div>
        <div className={classes.buttons}>
          <div>
            <div style={{height: "100%"}}>{children}</div>
          </div>
          <div>
            <Button className={classes.back} onClick={() => setActive(false)}>
              Назад
            </Button>
          </div>
        </div>
      </div>
    </Modal>
  );
};

export default ConfirmationModalWindow;
