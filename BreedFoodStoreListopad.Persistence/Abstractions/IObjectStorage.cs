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
        /// <param name="path">Путь, по которому располагается файл. Например, "folder/subfolder/file.jpg"</param>
        /// <param name="contentType">MIME тип файла. Например, "image/png"</param>
        /// <param name="stream">Стрим, который будет записан в файл</param>
        /// <returns></returns>
        public Task AddFile(string path, string contentType, Stream stream);

        /// <summary>
        /// Получить стрим с файлом
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Стрим с файлом</returns>
        public Task<Stream> GetFileAsync(string path);
    }
}
