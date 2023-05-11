﻿using BreedFoodStoreListopad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreedFoodStoreListopad.Persistence.Repositories
{
    public static class FakeData
    {
        public static List<Category> Categories { get; } = new List<Category>
        {
            new Category()
            {
                Id = new Guid("8ac303a0-6d9a-4c63-b916-305f7041fc95"),
                Name = "Полезные злаки и крупы",
                FileName = "Test1.jpg",
                OldNames = new List<string> { "Test2", "Test3", "Test4", "Test5" },
                OldFileNames = new List<string> { "Test2.jpg", "Test3.jpg" }
            },
            new Category()
            {
                Id = new Guid("f4c8dded-d2f4-4bfb-b96b-5d66adb7244d"),
                Name = "Кофе",
                FileName = "Coffe.jpg",
                DeletionDate = new DateTime(2023, 5, 11),
            },
            new Category()
            {
                Id = new Guid("d729d442-160a-4196-b36c-96c0090727ad"),
                Name = "Чай",
                FileName = "Tea.jpg",
                DeletionDate = new DateTime(2023, 5, 12),
            },
            new Category()
            {
                Id = new Guid("53a760b4-6c56-43d2-acb2-5ed9e0987ad8"),
                Name = "Напитки",
                FileName = "Example1.jpg",
                OldNames = new List<string> { "Example2", "Example3" },
                OldFileNames = new List<string> { "Example2.jpg", "Example3.jpg", "Example4.jpg" }
            },
            new Category()
            {
                Id = new Guid("2791fd2c-6b61-492b-8516-48728103c5ea"),
                Name = "Фрукты",
                FileName = "Category1.jpg",
            }
        };
    }
}
