using BreedFoodStoreListopad.Domain.Entities;

namespace BreedFoodStoreListopad.Persistence.Abstractions
{
    /// <summary>
    /// Интерфейс хранилища приложения
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Получить списко с категориями
        /// </summary>
        /// <param name="start">Начало отчета</param>
        /// <param name="length">Количество категорий</param>
        /// <returns>Список с категориями</returns>
        public Task<IEnumerable<Category>> GetCategoriesAsync(int start, int length);

        /// <summary>
        /// Получить категорию по id категории
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <returns>Категория</returns>
        public Task<Category> GetCategoryByIdAsync(Guid id);

        /// <summary>
        /// Получить категорию по названию категории
        /// </summary>
        /// <param name="name">Название категории</param>
        /// <returns>Категория</returns>
        public Task<Category> GetCategoryByNameAsync(string name);

        /// <summary>
        /// Установить новое имя у категории
        /// </summary>
        /// <param name="id">Id категории, у которой меняют имя</param>
        /// <param name="name">Новое имя категории</param>
        /// <returns></returns>
        public Task SetNewNameByIdAsync(Guid id, string name);

        /// <summary>
        /// Установить новое имя файла у категории
        /// </summary>
        /// <param name="id">Id категории, у которой меняют имя файла</param>
        /// <param name="filename">Новое имя файла</param>
        /// <returns></returns>
        public Task SetNewFileByIdAsync(Guid id, string filename);

        /// <summary>
        /// Установить имя, которое уже было у категории
        /// </summary>
        /// <param name="id">Id категории, у которой меняют имя</param>
        /// <param name="index">Индекс старого имени</param>
        /// <returns></returns>
        public Task SetOldNameByIdAsync(Guid id, int index);

        /// <summary>
        /// Установить имя файла, которое уже было у категории
        /// </summary>
        /// <param name="id">Id категории, у которой меняют имя файла</param>
        /// <param name="index">Индекс старого имени файла</param>
        /// <returns></returns>
        public Task SetOldFileNameByIdAsync(Guid id, int index);

        /// <summary>
        /// Удалить категорию по id
        /// </summary>
        /// <param name="id">Id удаляемой категории</param>
        /// <returns></returns>
        public Task DeleteCategoryByIdAsync(Guid id);

        /// <summary>
        /// Добавить новую категорию
        /// </summary>
        /// <param name="category">Новая категория</param>
        /// <returns></returns>
        public Task AddCategoryAsync(Category category);

        /// <summary>
        /// Содержит ли хранилище категорию с таким именем
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<bool> IsHasName(string name);

        /// <summary>
        /// Получить списко с удаленными категориями
        /// </summary>
        /// <param name="start">Начало отчета</param>
        /// <param name="length">Количество категорий</param>
        /// <returns>Список с удаленными категориями</returns>
        public Task<IEnumerable<Category>> GetCategoriesInTrashAsync(int start, int length);

        /// <summary>
        /// Установить корзину категории
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="date">Дата перемещения</param>
        /// <returns></returns>
        public Task SetCategoryDeletionDateAsync(Guid id, DateTime? date);

        /// <summary>
        /// Полностью удалить категорию
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <returns>Удаленная категория</returns>
        public Task<Category> FullyDeleteCategoryAsync(Guid id);
    }
}
