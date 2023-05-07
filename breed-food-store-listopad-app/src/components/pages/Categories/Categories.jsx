import React, { useEffect, useRef, useState } from "react";
import Category from "./../../../views/Category/Category";
import Header from "./../../layout/Header/Header";
import classes from "./Categories.module.css";
import ButtonAddCategory from "./../../../views/ButtonAddCategory/ButtonAddCategory";

const Categories = () => {
  const [categories, setCategories] = useState([
    {
      name: "Крупы",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
    {
      name: "Овощи",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
    {
      name: "Фрукты",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
    {
      name: "Крупы",
      filePath:
        "https://upload.wikimedia.org/wikipedia/commons/b/bc/Ab_food_02.jpg",
    },
    {
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

      <div className={classes.body}>
        <div className={classes.categories}>
          {categories.map((category) => (
            <div className={classes.category}>
              <Category name={category.name} filePath={category.filePath} />
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Categories;
