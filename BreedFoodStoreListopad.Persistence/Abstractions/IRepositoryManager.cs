namespace BreedFoodStoreListopad.Persistence.Abstractions
{
    /// <summary>
    /// Интерфейс руководителя хранилищами, содержит в себе все хранилища
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// Хранилище приложение для хранения данных
        /// </summary>
        public IRepository Repository { get; }

        /// <summary>
        /// Объектное хранилище приложение для хранения файлов
        /// </summary>
        public IObjectStorage ObjectStorage { get; }
    }
}
