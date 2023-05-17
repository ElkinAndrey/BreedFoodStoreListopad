import axios from "axios";

const URL = "https://localhost:7120/api";

export default class Service {
    static fullFilePath(filePath) {
        return `${URL}/GetImage/${filePath}`
    }

    static async getCategories(start, length) {
        const response = await axios.post(`${URL}/GetCategories/`, {
            start: start,
            length: length
        });
        return response;
    }

    static async getDeletedCategories(start, length) {
        const response = await axios.post(`${URL}/GetCategoriesInTrash/`, {
            start: start,
            length: length
        });
        return response;
    }

    static async moveCategoryToTrash(id, date) {
        await axios.put(`${URL}/MoveCategoryToTrash`, {
            id: id,
            moveDate: date
        });
    }

    static async returnCategoryFromTrash(id) {
        await axios.put(`${URL}/ReturnCategoryFromTrash/${id}`);
    }

    static async fullyDeleteCategory(id) {
        await axios.delete(`${URL}/FullyDeleteCategory/${id}`);
    }

    static async addCategory(name, file) {
        let formData = new FormData();
        formData.append("file", file);
        formData.append("name", name);
        await axios.post(`${URL}/AddCategory`, formData);
    }
}