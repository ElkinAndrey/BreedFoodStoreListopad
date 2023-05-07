import React, { useEffect, useRef, useState } from "react";
import Category from "./../../../views/Category/Category";
import Header from "./../../layout/Header/Header";
import classes from "./Categories.module.css";
import ButtonAddCategory from "./../../../views/ButtonAddCategory/ButtonAddCategory";
import Modal from "../../forms/Modal/Modal";
import Delete from "../../../views/Delete/Delete";

const Categories = () => {
  const [modal, setModal] = useState(false);

  const [categories, setCategories] = useState([
    {
      id: 1,
      name: "Крупы",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
    {
      id: 2,
      name: "Овощи",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
    {
      id: 3,
      name: "Фрукты",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
    {
      id: 4,
      name: "Крупы",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
    {
      id: 5,
      name: "Напитки",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
  ]);
  return (
    <div>
      <Header>
        <div className={classes.headerButtons}>
          <ButtonAddCategory />
        </div>
      </Header>
      <Modal
        active={modal}
        setActive={setModal}
        style={{
          borderRadius: "10px",
          padding: "20px",
          width: "380px",
          border: "3px solid var(--button-delete)",
        }}
      >
        <Delete
          logo={"Удаление категории"}
          text={'Вы уверены, что хотите удалить категорию "Напитки"?'}
          deleteAction={() => {
            console.log("Успешно удалено");
            setModal(false);
          }}
          backAction={() => setModal(false)}
        />
      </Modal>
      
      <div className={classes.body}>
        <div className={classes.categories}>
          {categories.map((category) => (
            <div key={category.id} className={classes.category}>
              <Category
                name={category.name}
                filePath={category.filePath}
                onClickDelete={() => {
                  setModal(true);
                }}
              />
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Categories;
