using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Service.Services;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="start">Начало отчета</param>
        /// <param name="length">Длина среза</param>
        /// <returns>Список категорий</returns>
        public Task<IEnumerable<Category>> GetCategoriesAsync(int? start, int? length);

        /// <summary>
        /// Получить списко с удаленными категориями
        /// </summary>
        /// <param name="start">Начало отчета</param>
        /// <param name="length">Количество категорий</param>
        /// <returns>Список с удаленными категориями</returns>
        public Task<IEnumerable<Category>> GetCategoriesInTrashAsync(int? start, int? length);

        /// <summary>
        /// Получить картинку по пути
        /// </summary>
        /// <param name="path">Путь к картинке</param>
        /// <param name="imageCreator">Метод для создания картинки из стрима</param>
        /// <returns>Картинка</returns>
        public Task<FileStreamResult> GetImageAsync(string path, ImageCreator imageCreator);

        /// <summary>
        /// Переместить категорию в список удаленных категорий
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="date">Дата перемещения</param>
        /// <returns></returns>
        public Task MoveCategoryToTrashAsync(Guid? id, DateTime? date);

        /// <summary>
        /// Вернуть категорию из списока удаленных категорий
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <returns></returns>
        public Task ReturnCategoryFromTrashAsync(Guid? id);
    }
}
