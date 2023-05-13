using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Persistence.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BreedFoodStoreListopad.Persistence.Repositories
{
    /// <summary>
    /// Фейковое хранилище с данными, находящееся прямо на сервере
    /// </summary>
    public class FakeRepository : IRepository
    {
        private List<Category> _categories;
        public FakeRepository()
        {
            _categories = FakeData.Categories;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await Task.Run(() => _categories.Add(category));
        }

        public async Task DeleteCategoryByIdAsync(Guid id)
        {
            await Task.Run(()
                => _categories = _categories
                    .Where(category => category.Id != id)
                    .ToList()
            );
        }

        public async Task<Category> FullyDeleteCategoryAsync(Guid id)
        {
            return await Task.Run(() =>
                {
                    Category removeCcategory = _categories.Where(category => category.Id == id).First();
                    _categories.Remove(removeCcategory);
                    return removeCcategory;
                }
            );
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int start, int length)
        {
            return await Task.Run(()
                => _categories.Where(category => category.DeletionDate is null)
                              .OrderBy(category => category.Name)
                              .Skip(start)
                              .Take(length)
            );
        }

        public async Task<IEnumerable<Category>> GetCategoriesInTrashAsync(int start, int length)
        {
            return await Task.Run(()
                => _categories.Where(category => category.DeletionDate is not null)
                              .OrderByDescending(category => category.DeletionDate)
                              .Skip(start)
                              .Take(length)
            );
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await Task.Run(()
                => _categories.Find(category => category.Id == id)
            );
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await Task.Run(()
                => _categories.Find(category => category.Name == name)
            );
        }

        public async Task<bool> IsHasName(string name)
        {
            return await Task.Run(()
                => _categories.Any(category => category.Name == name)
            );
        }

        public async Task SetCategoryDeletionDateAsync(Guid id, DateTime? date)
        {
            await Task.Run(()
                => _categories.Find(category => category.Id == id).DeletionDate = date
            );
        }

        public async Task SetNewFileByIdAsync(Guid id, string filename)
        {
            await Task.Run(()
                => _categories.Find(category => category.Id == id).FileName = filename
            );

        }

        public async Task SetNewNameByIdAsync(Guid id, string name)
        {
            await Task.Run(()
                => _categories.Find(category => category.Id == id).Name = name
            );
        }

        public async Task SetOldFileNameByIdAsync(Guid id, int index)
        {
            await Task.Run(()
                => _categories.Find(category => category.Id == id).SetOldFileName(index)
            );
        }

        public async Task SetOldNameByIdAsync(Guid id, int index)
        {
            await Task.Run(()
                => _categories.Find(category => category.Id == id).SetOldName(index)
            );
        }
    }
}
