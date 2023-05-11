﻿using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Persistence.Abstractions;

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
