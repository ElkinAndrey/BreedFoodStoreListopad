import React from "react";
import Loader from "./../../components/forms/Loader/Loader";
import classes from "./PageFetching.module.css";

const PageFetching = ({ loading, error, children }) => {
  return (
    <div className={classes.body}>
      {!loading && (Object.keys(error).length === 0 || !error) ? (
        <div className={classes.content}>{children}</div>
      ) : (
        <div className={classes.fetching}>
          {loading ? (
            <Loader />
          ) : (
            (Object.keys(error).length !== 0 && error) && (
              <div className={classes.error}>
                {error?.response?.data || error?.message}
              </div>
            )
          )}
        </div>
      )}
    </div>
  );
};

export default PageFetching;
