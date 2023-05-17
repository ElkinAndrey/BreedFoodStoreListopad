import React, { useContext, useEffect, useState } from "react";
import classes from "./AddCategory.module.css";
import Center from "./../../forms/Center/Center";
import Category from "./../../../views/Category/Category";
import Input from "./../../forms/Input/Input";
import Button from "./../../forms/Button/Button";
import { Link, useNavigate } from "react-router-dom";
import Service from "./../../../api/Service";
import { useFetching } from "../../../hooks/useFetching";
import ButtonAdd from "./../../../views/ButtonAdd/ButtonAdd";
import { Context } from "./../../../context/context";

const AddCategory = () => {
  const baseImage =
    "data:image/png;base64,R0lGODlhFAAUAIAAAP///wAAACH5BAEAAAAALAAAAAAUABQAAAIRhI+py+0Po5y02ouz3rz7rxUAOw==";

  const [name, setName] = useState("");
  const [fileName, setFileName] = useState("");
  const [imageFile, setImageFile] = useState(null);
  const [imageSrc, setImageSrc] = useState(baseImage);
  const { notifications, setNotifications } = useContext(Context);
  const [fileNotSelected, setFileNotSelected] = useState(false);
  const navigate = useNavigate();

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async (n, i) => {
      await Service.addCategory(n, i);
    }
  );

  const showPreview = (e) => {
    if (e.target.files && e.target.files[0]) {
      let image = e.target.files[0];
      setFileName(image.name);
      const reader = new FileReader();
      reader.onload = (x) => {
        setImageFile(image);
        setImageSrc(x.target.result);
      };
      reader.readAsDataURL(image);
      setFileNotSelected(false);
    }
  };

  const Add = () => {
    if (fileName === "" || !fileName) {
      setFileNotSelected(true);
      return;
    }
    fetchCategories(name, imageFile);
  };
  return (
    <Center className={classes.body}>
      <div className={classes.logo}>Добавить категорию</div>
      <div style={{ display: "flex" }}>
        <div className={classes.data}>
          <div className={classes.sublogo}>Название категории</div>
          <Input
            value={name}
            setValue={setName}
            width="300px"
            className={classes.inputName}
            maxLength={22}
          />
          <div className={classes.chooseImage}>
            <div className={classes.sublogo}>Картинка</div>
            <div style={{ display: "inline-block" }}>
              <img
                className={classes.image}
                hidden={baseImage === imageSrc ? true : false}
                src={imageSrc}
                alt={""}
              />
              <div
                className={classes.drop}
                hidden={baseImage === imageSrc ? false : true}
              >
                <div className={classes.camera}>
                  <img src="/images/camera.png" alt="" />
                  <div>Перетащите изображение</div>
                </div>
              </div>
              <div
                className={classes.fileName}
                style={fileNotSelected ? { color: "var(--button-delete)" } : {}}
              >
                {fileName === "" ? "Файл не выбран" : fileName}
              </div>
            </div>
            <div>
              <label className={classes.chooseImageButton} htmlFor="formId">
                <input
                  name=""
                  type="file"
                  accept="image/*"
                  onChange={showPreview}
                  id="formId"
                  hidden
                />
                Выбрать картинку
              </label>
            </div>
          </div>
          <div className={classes.buttons}>
            <div className={classes.buttonAdd}>
              <ButtonAdd
                text="Добавить"
                loadingText="Добавление"
                loading={isCategoriesLoading}
                onClick={() => {
                  if (fileName === "" || !fileName) {
                    setFileNotSelected(true);
                    return;
                  }
                  fetchCategories(name, imageFile);
                }}
                actionsAfter={() => {
                  if (
                    Object.keys(categoriesError).length === 0 ||
                    !categoriesError
                  ) {
                    navigate("/");
                  }
                }}
                error={categoriesError}
                color={"var(--button)"}
                colorActive={"var(--button-active)"}
                notifications={notifications}
                setNotifications={setNotifications}
                successfulMessage={`Категория "${name}" успешно добавлена`}
                failedMessage={`Не удалось добавить категорию из-за ошибки "${
                  categoriesError?.response?.data || categoriesError?.message
                }"`}
              />
            </div>
            <Link to="/">
              <Button className={classes.buttonBack}>Отмена</Button>
            </Link>
          </div>
        </div>
        <div className={classes.preview}>
          <div>
            <div className={classes.sublogo}>Предпросмотр</div>
            <Category
              name={name}
              filePath={imageSrc === baseImage ? "" : imageSrc}
            />
          </div>
        </div>
      </div>
    </Center>
  );
};

export default AddCategory;
