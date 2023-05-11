import React from "react";
import classes from "./UpdateCategory.module.css";
import { useParams } from "react-router-dom";
import Header from "../../layout/Header/Header";
import ButtonWithImage from "./../../../views/ButtonWithImage/ButtonWithImage";

const UpdateCategory = () => {
  const params = useParams();
  return (
    <div>
      <Header>
        <div className={classes.headerButtons}>
          <ButtonWithImage
            text={"На главную"}
            imagePath={"/images/back.png"}
            to={"/"}
          />
        </div>
      </Header>
      <div>Название категории : {params.name}</div>
    </div>
  );
};

export default UpdateCategory;
