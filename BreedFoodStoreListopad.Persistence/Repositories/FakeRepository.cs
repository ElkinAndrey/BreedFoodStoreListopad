using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Persistence.Abstractions;

namespace BreedFoodStoreListopad.Persistence.Repositories
{
    public class FakeRepository : IRepository
    {
        private List<Category> _categories = new List<Category>
        {
            new Category()
            {
                Name = "Test1",
                FileName = "Test1.jpg",
                OldNames = new List<string> { "Test2", "Test3", "Test4", "Test5" },
                OldFileNames = new List<string> { "Test2.jpg", "Test3.jpg" }
            },
            new Category()
            {
                Name = "Example1",
                FileName = "Example1.jpg",
                OldNames = new List<string> { "Example2", "Example3" },
                OldFileNames = new List<string> { "Example2.jpg", "Example3.jpg", "Example4.jpg" }
            },
            new Category()
            {
                Name = "Category1",
                FileName = "Category1.jpg",
            }
        };

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

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int start, int length)
        {
            return await Task.Run(()
                => _categories.Skip(start).Take(length)
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
