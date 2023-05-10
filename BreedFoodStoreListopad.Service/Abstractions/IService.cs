using BreedFoodStoreListopad.Domain.Entities;

namespace BreedFoodStoreListopad.Service.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса приложения
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Добавить новую категорию
        /// </summary>
        /// <param name="name">Название категории</param>
        /// <param name="fileName">Название файла</param>
        /// <param name="contentType">MIME тип файла. Например, "image/png"</param>
        /// <param name="stream">Стрим, который будет записан в файл</param>
        /// <returns></returns>
        public Task AddCategoryAsync(string name, string fileName, string contentType, Stream stream);

        /// <summary>
        /// Получить срез продуктовых категорий
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public Task<IEnumerable<Category>> GetCategoriesAsync(int? start, int? length);
    }
}
