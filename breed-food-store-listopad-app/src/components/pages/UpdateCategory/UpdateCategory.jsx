import React from "react";
import classes from "./UpdateCategory.module.css";
import { useParams } from "react-router-dom";
import Header from "../../layout/Header/Header";

const UpdateCategory = () => {
  const params = useParams();
  return (
    <div>
      <Header />
      <div>Название категории : {params.name}</div>
    </div>
  );
};

export default UpdateCategory;
