import axios from "axios";

const URL = "https://localhost:7120/api";

export default class Service {
    static fullFilePath(filePath){
        return `${URL}/GetImage/${filePath}`
    }

    static async getCategories(start, length) {
        const response = await axios.post(`${URL}/GetCategories/`, {
            start: start,
            length: length
        });
        return response;
    }
}