using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Persistence.Abstractions;
using BreedFoodStoreListopad.Service.Abstractions;
using BreedFoodStoreListopad.Service.Exceptions;
using BreedFoodStoreListopad.Service.Features;

namespace BreedFoodStoreListopad.Service.Services
{
    public class Service : IService
    {
        private IRepositoryManager _manager;

        public Service(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task AddCategoryAsync(string name, string fileName, string contentType, Stream stream)
        {
            if (string.IsNullOrEmpty(name))
                throw new EmptyNameException();

            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(contentType) || stream == null || stream.Length == 0)
                throw new EmptyFileException();

            if (!MIME.IsImage(contentType))
                throw new NotImageException();

            if (await _manager.Repository.IsHasName(name))
                throw new NameAlreadyExistsException();

            try
            {
                string fileExtension = Path.GetExtension(fileName);
                string newFileName = Guid.NewGuid().ToString() + fileExtension;
                await _manager.Repository.AddCategoryAsync(new Category(name, newFileName));
                await _manager.ObjectStorage.AddFile(Category.ImagesFolder, newFileName, contentType, stream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
