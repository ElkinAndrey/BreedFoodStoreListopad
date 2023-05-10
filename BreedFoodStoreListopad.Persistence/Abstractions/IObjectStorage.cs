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
        /// <param name="folder">Папка, в которой будет хранится файл. Например, "folder/subfolder"</param>
        /// <param name="fileName">Имя добавляемого файла. Например "123.jpg"</param>
        /// <param name="contentType">MIME тип файла. Например, "image/png"</param>
        /// <param name="stream">Стрим, который будет записан в файл</param>
        /// <returns></returns>
        public Task AddFile(string folder, string fileName, string contentType, Stream stream);
    }
}
