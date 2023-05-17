import React from "react";
import classes from "./Category.module.css";
import { Link } from "react-router-dom";

const Category = ({
  name,
  filePath = "",
  to = "",
  onClickDelete = () => {},
}) => {
  return (
    <div>
      <div className={classes.category}>
        <div className={classes.category_content}>
          <div className={classes.logo}>
            <div
              style={{
                height: "100%",
                borderRadius: "10px",
                alignItems: "center",
                display: "flex",
                justifyContent: "center",
              }}
              className={`${name === "" || !name ? "skeletonImage" : ""}`}
            >
              {name}
            </div>
          </div>
          <div
            style={{ borderRadius: "10px" }}
            className={`${filePath === "" || !filePath ? "skeletonImage" : ""}`}
          >
            <img
              className={classes.image}
              src={
                filePath === "" || !filePath
                  ? "data:image/png;base64,R0lGODlhFAAUAIAAAP///wAAACH5BAEAAAAALAAAAAAUABQAAAIRhI+py+0Po5y02ouz3rz7rxUAOw=="
                  : filePath
              }
              alt=""
            />
          </div>
          <div className={classes.buttons}>
            <Link to={to} className={classes.button_update}>
              Изменить
            </Link>
            <button className={classes.button_delete} onClick={onClickDelete}>
              <img src="/images/trash.png" alt="" />
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Category;
