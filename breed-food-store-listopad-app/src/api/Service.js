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
        await axios.post(`${URL}/MoveCategoryToTrash`, {
            id: id,
            moveDate: date
        });
    }
}