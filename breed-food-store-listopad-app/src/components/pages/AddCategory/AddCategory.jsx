import React from "react";
import classes from "./AddCategory.module.css";
import Header from "../../layout/Header/Header";
import ButtonWithImage from './../../../views/ButtonWithImage/ButtonWithImage';

const AddCategory = () => {
  return (
    <div>
      {" "}
      <Header>
        <div className={classes.headerButtons}>
          <ButtonWithImage
            text={"На главную"}
            imagePath={"/images/back.png"}
            to={"/"}
          />
        </div>
      </Header>
      <div>Добавить категорию</div>
    </div>
  );
};

export default AddCategory;
