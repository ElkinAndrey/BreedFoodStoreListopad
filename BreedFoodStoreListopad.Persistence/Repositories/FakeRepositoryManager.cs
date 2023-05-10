using BreedFoodStoreListopad.Persistence.Abstractions;

namespace BreedFoodStoreListopad.Persistence.Repositories
{
    /// <summary>
    /// Фейковый руководитель хранилищами
    /// </summary>
    public class FakeRepositoryManager : IRepositoryManager
    {
        /// <summary>
        /// Хранилище приложение для хранения данных
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Объектное хранилище приложение для хранения файлов
        /// </summary>
        private readonly IObjectStorage _objectStorage;
        
        /// <summary>
        /// Фейковый руководитель хранилищами
        /// </summary>
        public FakeRepositoryManager()
        {
            _repository = new FakeRepository();
            _objectStorage = new FakeObjectStorage();
        }

        public IRepository Repository => _repository;

        public IObjectStorage ObjectStorage => _objectStorage;
    }
}
