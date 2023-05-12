import React, { useEffect, useState } from "react";
import classes from "./ButtonDelete.module.css";
import Button from "./../../components/forms/Button/Button";
import Loader from "./../../components/forms/Loader/Loader";

const ButtonDelete = ({ text, loadingText, loading, onClick, afterClick }) => {
  const [subloading, setSubloading] = useState(false);

  useEffect(() => {
    if (loading && !subloading) {
      setSubloading(true);
    }

    if (subloading && !loading) {
      setSubloading(false);
      afterClick();
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
                <Loader width="35px" color="var(--button-delete)" />
              </div>
              <div>{loadingText}</div>
            </div>
          ) : (
            <Button className={classes.button} onClick={onClick}>
              {text}
            </Button>
          )}
        </div>
      )}
    </div>
  );
};

export default ButtonDelete;
