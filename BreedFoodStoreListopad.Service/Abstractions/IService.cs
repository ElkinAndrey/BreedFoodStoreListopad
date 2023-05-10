using BreedFoodStoreListopad.Domain.Entities;

namespace BreedFoodStoreListopad.Service.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса приложения
    /// </summary>
    internal interface IService
    {
        /// <summary>
        /// Добавить новую категорию
        /// </summary>
        /// <param name="name">Название категории</param>
        /// <param name="fileName">Название файла</param>
        /// <param name="contentType">MIMO тип файла. Например, "image/png"</param>
        /// <param name="stream">Стрим, который будет записан в файл</param>
        /// <returns></returns>
        public Task AddCategoryAsync(string name, string fileName, string contentType, Stream stream);
    }
}
