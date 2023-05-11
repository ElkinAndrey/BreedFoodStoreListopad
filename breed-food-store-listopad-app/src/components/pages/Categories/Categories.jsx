import React, { useEffect, useRef, useState } from "react";
import Category from "./../../../views/Category/Category";
import Header from "./../../layout/Header/Header";
import classes from "./Categories.module.css";
import ButtonAddCategory from "./../../../views/ButtonAddCategory/ButtonAddCategory";
import Modal from "../../forms/Modal/Modal";
import Delete from "../../../views/Delete/Delete";
import { useFetching } from "./../../../hooks/useFetching";
import Service from "../../../api/Service";
import PageFetching from "./../../../views/PageFetching/PageFetching";
import PaginationBar from "../../forms/PaginationBar/PaginationBar";

const Categories = () => {
  const dataFetchedRef = useRef(false);
  const [paginationPage, setPaginationPage] = useState(1);
  const [modal, setModal] = useState(false);
  const [categories, setCategories] = useState();
  const [delName, setDelName] = useState("");

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async (start, length) => {
      const response = await Service.getCategories(start, length);
      setCategories(response.data);
    }
  );

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchCategories(0, 100);
  }, []);

  return (
    <div className={classes.all}>
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
          text={`Вы уверены, что хотите удалить категорию "${delName}"?`}
          deleteAction={() => {
            console.log("Успешно удалено");
            setModal(false);
          }}
          backAction={() => setModal(false)}
        />
      </Modal>

      <div className={classes.body}>
        <PageFetching loading={isCategoriesLoading} error={categoriesError}>
          {categories?.length === 0 ? (
            <div className={classes.hasNotCategories}>
              Категории отсутствуют
            </div>
          ) : (
            <div className={classes.content}>
              <div className={classes.categories}>
                {categories?.map((category) => (
                  <div key={category.id} className={classes.category}>
                    <Category
                      name={category.name}
                      filePath={Service.fullFilePath(category.filePath)}
                      onClickDelete={() => {
                        setDelName(category.name);
                        setModal(true);
                      }}
                    />
                  </div>
                ))}
              </div>
              <PaginationBar
                className={classes.paginationBar}
                start={1}
                end={13}
                page={paginationPage}
                setPage={setPaginationPage}
              />
            </div>
          )}
        </PageFetching>
      </div>
    </div>
  );
};

export default Categories;
