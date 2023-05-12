import React, { useEffect, useRef, useState } from "react";
import classes from "./DeletedCategories.module.css";
import Header from "./../../layout/Header/Header";
import Service from "./../../../api/Service";
import { useFetching } from "./../../../hooks/useFetching";
import PageFetching from "./../../../views/PageFetching/PageFetching";
import PaginationBar from "./../../forms/PaginationBar/PaginationBar";
import DeletedCategory from "../../../views/DeletedCategory/DeletedCategory";
import Modal from "./../../forms/Modal/Modal";
import Delete from "./../../../views/Delete/Delete";
import Restore from "./../../../views/Restore/Restore";
import ButtonWithImage from "./../../../views/ButtonWithImage/ButtonWithImage";
import ConfirmationModalWindow from "./../../../views/ConfirmationModalWindow/ConfirmationModalWindow";

const DeletedCategories = () => {
  const dataFetchedRef = useRef(false);
  const [paginationPage, setPaginationPage] = useState(1);
  const [categories, setCategories] = useState();
  const [modalRestore, setModalRestore] = useState(false);
  const [modalDelete, setModalDelete] = useState(false);
  const [resName, setResName] = useState("");
  const [delName, setDelName] = useState("");

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async (start, length) => {
      const response = await Service.getDeletedCategories(start, length);
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
          <ButtonWithImage
            text={"На главную"}
            imagePath={"/images/back.png"}
            to={"/"}
          />
        </div>
      </Header>

      <ConfirmationModalWindow
        active={modalRestore}
        setActive={setModalRestore}
        logo={"Востановить категорию"}
        text={`Вы уверены, что хотите востановить категорию "${resName}"?`}
        borderColor="var(--button-restore)"
        width="380px"
      ></ConfirmationModalWindow>

      <ConfirmationModalWindow
        active={modalDelete}
        setActive={setModalDelete}
        logo={"Полностью удалить категорию"}
        text={`Вы уверены, что хотите полностью удалить категорию "${delName}"?`}
        borderColor="var(--button-delete)"
        width="380px"
      ></ConfirmationModalWindow>

      <div className={classes.body}>
        <PageFetching
          loading={isCategoriesLoading}
          loadingText={"Загрузка категорий"}
          error={categoriesError}
        >
          {categories?.length === 0 ? (
            <div className={classes.hasNotCategories}>
              Категории отсутствуют
            </div>
          ) : (
            <div className={classes.content}>
              <div className={classes.categories}>
                {categories?.map((category) => (
                  <div key={category.id} className={classes.category}>
                    <DeletedCategory
                      category={category}
                      onRestore={() => {
                        setResName(category.name);
                        setModalRestore(true);
                      }}
                      onDelete={() => {
                        setDelName(category.name);
                        setModalDelete(true);
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

export default DeletedCategories;
