namespace BreedFoodStoreListopad.Persistence.Abstractions
{
    /// <summary>
    /// Интерфейс объектного хранилища файлов
    /// </summary>
    public interface IObjectStorage
    {
        /// <summary>
        /// Добавить новый файл в объектное хранилище
        /// </summary>
        /// <param name="filePath">Путь, по которому располагается файл. Например, "folder/subfolder/file.jpg"</param>
        /// <param name="contentType">MIME тип файла. Например, "image/png"</param>
        /// <param name="stream">Стрим, который будет записан в файл</param>
        /// <returns></returns>
        public Task AddFileAsync(string filePath, string contentType, Stream stream);

        /// <summary>
        /// Получить стрим с файлом
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Стрим с файлом</returns>
        public Task<Stream> GetFileAsync(string filePath);

        /// <summary>
        /// Удалить папку
        /// </summary>
        /// <param name="folderPath">Путь к папке</param>
        /// <returns></returns>
        public Task DeleteFolderAsync(string folderPath);
    }
}
