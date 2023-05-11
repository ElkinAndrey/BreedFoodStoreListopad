export default class GetDate {
    static DateToString(date) {
        if (!date) {
            return "Дата не распознана";
        }

        let dateVar = new Date(date);
        return `${dateVar.getDate()}-${dateVar.getMonth() + 1}-${dateVar.getFullYear()}`
    }
}