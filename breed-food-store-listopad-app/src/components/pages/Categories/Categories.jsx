import React, { useContext, useEffect, useRef, useState } from "react";
import Category from "./../../../views/Category/Category";
import Header from "./../../layout/Header/Header";
import classes from "./Categories.module.css";
import ButtonWithImage from "../../../views/ButtonWithImage/ButtonWithImage";
import { useFetching } from "./../../../hooks/useFetching";
import Service from "../../../api/Service";
import PageFetching from "./../../../views/PageFetching/PageFetching";
import PaginationBar from "../../forms/PaginationBar/PaginationBar";
import ConfirmationModalWindow from "./../../../views/ConfirmationModalWindow/ConfirmationModalWindow";
import ButtonDelete from "./../../../views/ButtonDelete/ButtonDelete";
import { Context } from "./../../../context/context";
import Notification from "../../forms/Notification/Notification";
import AddNotification from "./../../../utils/AddNotification";

const Categories = () => {
  const dataFetchedRef = useRef(false);
  const [paginationPage, setPaginationPage] = useState(1);
  const [modal, setModal] = useState(false);
  const [categories, setCategories] = useState();
  const [delCategory, setDelCategory] = useState("");
  const { notifications, setNotifications } = useContext(Context);

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async (start, length) => {
      const response = await Service.getCategories(start, length);
      setCategories(response.data);
    }
  );

  const [fetchDelete, isDeleteLoading, deleteError] = useFetching(
    async (id, date) => {
      await Service.moveCategoryToTrash(id, date);
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
            text={"Удаленные категории"}
            imagePath={"/images/trash.png"}
            to={"/удаленные_категории"}
            style={{ marginRight: "10px" }}
          />
          <ButtonWithImage
            text={"Добавить категорию"}
            imagePath={"/images/category.png"}
            to={"/добавить_категорию"}
          />
        </div>
      </Header>

      <ConfirmationModalWindow
        active={modal}
        setActive={setModal}
        logo={"Удаление категории"}
        text={`Вы уверены, что хотите удалить категорию "${delCategory.name}"?`}
        borderColor="var(--button-delete)"
        width="380px"
      >
        <ButtonDelete
          text="Удалить"
          loadingText="Удаление"
          loading={isDeleteLoading}
          onClick={() => {
            fetchDelete(delCategory.id, new Date());
          }}
          setModal={setModal}
          er={deleteError}
          array={categories}
          setArray={setCategories}
          color={"var(--button-delete)"}
          colorActive={"var(--button-delete-active)"}
          processedElement={delCategory}
          notifications={notifications}
          setNotifications={setNotifications}
          successfulMessage={`Категория "${delCategory.name}" успешно перемещена в корзину`}
          failedMessage={`Не удалось переместить категорию "${
            delCategory.name
          }" в корзину из-за ошибки "
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
                      to={`/изменить_категорию/${category.name.replaceAll(
                        " ",
                        "_"
                      )}`}
                      onClickDelete={() => {
                        setDelCategory(category);
                        setModal(true);
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

export default Categories;
