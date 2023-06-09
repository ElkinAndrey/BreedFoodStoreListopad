import React, { useContext, useEffect, useRef, useState } from "react";
import classes from "./DeletedCategories.module.css";
import Header from "./../../layout/Header/Header";
import Service from "./../../../api/Service";
import { useFetching } from "./../../../hooks/useFetching";
import PageFetching from "./../../../views/PageFetching/PageFetching";
import PaginationBar from "./../../forms/PaginationBar/PaginationBar";
import DeletedCategory from "../../../views/DeletedCategory/DeletedCategory";
import ButtonWithImage from "./../../../views/ButtonWithImage/ButtonWithImage";
import ConfirmationModalWindow from "./../../../views/ConfirmationModalWindow/ConfirmationModalWindow";
import ButtonDelete from "./../../../views/ButtonDelete/ButtonDelete";
import { Context } from "./../../../context/context";
import AddNotification from "./../../../utils/AddNotification";
import Notification from "../../forms/Notification/Notification";

const DeletedCategories = () => {
  const dataFetchedRef = useRef(false);
  const [paginationPage, setPaginationPage] = useState(1);
  const [categories, setCategories] = useState();
  const [modalRestore, setModalRestore] = useState(false);
  const [modalDelete, setModalDelete] = useState(false);
  const [res, setRes] = useState();
  const [del, setDel] = useState();
  const { notifications, setNotifications } = useContext(Context);

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async (start, length) => {
      const response = await Service.getDeletedCategories(start, length);
      setCategories(response.data);
    }
  );

  const [fetchReturn, isReturnLoading, returnError] = useFetching(
    async (id) => {
      await Service.returnCategoryFromTrash(id);
    }
  );

  const [fetchDelete, isDeleteLoading, deleteError] = useFetching(
    async (id) => {
      await Service.fullyDeleteCategory(id);
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
        text={`Вы уверены, что хотите востановить категорию "${res?.name}"?`}
        borderColor="var(--button-restore)"
        width="380px"
      >
        <ButtonDelete
          text="Востановить"
          loadingText="Востановление"
          loading={isReturnLoading}
          onClick={() => {
            fetchReturn(res.id);
          }}
          setModal={setModalRestore}
          er={returnError}
          array={categories}
          setArray={setCategories}
          color={"var(--button-restore)"}
          colorActive={"var(--button-restore-active)"}
          processedElement={res}
          notifications={notifications}
          setNotifications={setNotifications}
          successfulMessage={`Категория "${res?.name}" успешно востановлена`}
          failedMessage={`Не удалось востановить категорию "${
            res?.name
          }" из-за ошибки "${
            returnError?.response?.data || returnError?.message
          }"`}
        />
      </ConfirmationModalWindow>

      <ConfirmationModalWindow
        active={modalDelete}
        setActive={setModalDelete}
        logo={"Полностью удалить категорию"}
        text={`Вы уверены, что хотите полностью удалить категорию "${del?.name}"?`}
        borderColor="var(--button-delete)"
        width="380px"
      >
        <ButtonDelete
          text="Удалить"
          loadingText="Удаление"
          loading={isDeleteLoading}
          onClick={() => {
            fetchDelete(del.id, new Date());
          }}
          setModal={setModalDelete}
          er={deleteError}
          array={categories}
          setArray={setCategories}
          color={"var(--button-delete)"}
          colorActive={"var(--button-delete-active)"}
          processedElement={del}
          notifications={notifications}
          setNotifications={setNotifications}
          successfulMessage={`Категория "${del?.name}" успешно удалена`}
          failedMessage={`Не удалось удалить категорию "${del?.name}" из-за
      ошибки "
      ${deleteError?.response?.data || deleteError?.message}"`}
        />
      </ConfirmationModalWindow>

      <div className={classes.body}>
        <PageFetching
          loading={isCategoriesLoading}
          loadingText={"Загрузка категорий"}
          error={categoriesError}
        >
          {categories?.length === 0 ? (
            <div className={classes.hasNotCategories}>
              Удаленные категории отсутствуют
            </div>
          ) : (
            <div className={classes.content}>
              <div className={classes.categories}>
                {categories?.map((category) => (
                  <div key={category.id} className={classes.category}>
                    <DeletedCategory
                      category={category}
                      onRestore={() => {
                        setRes(category);
                        setModalRestore(true);
                      }}
                      onDelete={() => {
                        setDel(category);
                        setModalDelete(true);
                      }}
                    />
                  </div>
                ))}
              </div>
              {/* <PaginationBar
                className={classes.paginationBar}
                start={1}
                end={13}
                page={paginationPage}
                setPage={setPaginationPage}
              /> */}
            </div>
          )}
        </PageFetching>
      </div>
    </div>
  );
};

export default DeletedCategories;
