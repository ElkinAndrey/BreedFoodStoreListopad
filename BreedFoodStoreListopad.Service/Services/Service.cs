﻿using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Persistence.Abstractions;
using BreedFoodStoreListopad.Service.Abstractions;
using BreedFoodStoreListopad.Service.Exceptions;
using BreedFoodStoreListopad.Service.Features;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BreedFoodStoreListopad.Service.Services
{
    /// <summary>
    /// Метод для получения картинки из стрима
    /// </summary>
    /// <param name="fileStream">Стрим картинки</param>
    /// <param name="contentType">MIME тип файла</param>
    /// <returns>Картинка</returns>
    public delegate FileStreamResult ImageCreator(Stream fileStream, string contentType);

    /// <summary>
    /// Сервис приложения
    /// </summary>
    public class Service : IService
    {
        private IRepositoryManager _manager;

        /// <summary>
        /// Руководитель хранилищами приложения
        /// </summary>
        public Service(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task AddCategoryAsync(string? name, string? fileName, string? contentType, Stream? stream)
        {
            if (string.IsNullOrEmpty(name))
                throw new EmptyNameException();

            if (!name.All(ch => ch != '_'))
                throw new NameContainsInvalidCharacterException('_');

            int expectedLength = 22;
            if (name.Length > expectedLength)
                throw new NameTooLongException(expectedLength, name.Length);

            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(contentType) || stream == null || stream.Length == 0)
                throw new EmptyFileException();

            if (!MIME.IsImage(contentType))
                throw new NotImageException();

            if (await _manager.Repository.IsHasName(name))
                throw new NameAlreadyExistsException();

            string fileExtension = Path.GetExtension(fileName);
            string newFileName = Guid.NewGuid().ToString() + fileExtension;
            Category category = new Category(name, newFileName);
            var addCategiryTask = _manager.Repository.AddCategoryAsync(category);
            var addFileTask = _manager.ObjectStorage.AddFileAsync(category.FilePath, contentType, stream);
            await addCategiryTask;
            await addFileTask;

            
        }

        public async Task FullyDeleteCategoryAsync(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                throw new EmptyIdException();

            Guid notNullId = id ?? Guid.Empty;

            var removeCcategory = await _manager.Repository.FullyDeleteCategoryAsync(notNullId);
            await _manager.ObjectStorage.DeleteFolderAsync(removeCcategory.FolderPath);

        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int? start, int? length)
        {
            if (start is null)
                throw new EmptyStartException();

            if (length is null)
                throw new EmptyLengthException();

            int notNullStart = start ?? 0;
            int notNullLength = length ?? 0;

            if (notNullStart < 0)
                throw new NegativeStartException(notNullStart);

            if (notNullLength < 0)
                throw new NegativeLengthException(notNullLength);

            return await _manager.Repository.GetCategoriesAsync(notNullStart, notNullLength);
        }

        public async Task<IEnumerable<Category>> GetCategoriesInTrashAsync(int? start, int? length)
        {
            if (start is null)
                throw new EmptyStartException();

            if (length is null)
                throw new EmptyLengthException();

            int notNullStart = start ?? 0;
            int notNullLength = length ?? 0;

            if (notNullStart < 0)
                throw new NegativeStartException(notNullStart);

            if (notNullLength < 0)
                throw new NegativeLengthException(notNullLength);

            return await _manager.Repository.GetCategoriesInTrashAsync(notNullStart, notNullLength);
        }

        public async Task<FileStreamResult> GetImageAsync(string path, ImageCreator imageCreator)
        {
            string contentType = MIME.GetContentType(path);
            if (contentType == MIME.MIMETypes.ApplicationOctetStream)
                throw new MIMETypesException();

            FileStreamResult image;
            Stream stream = await _manager.ObjectStorage.GetFileAsync(path);
            image = imageCreator(stream, contentType);
            
            return image;
        }

        public async Task MoveCategoryToTrashAsync(Guid? id, DateTime? date)
        {
            if (id == null || id == Guid.Empty)
                throw new EmptyIdException();

            if (date == null || date == DateTime.MinValue)
                throw new EmptyDateException();

            Guid notNullId = id ?? Guid.Empty;
            DateTime notNullDate = date ?? DateTime.Now;

            await _manager.Repository.SetCategoryDeletionDateAsync(notNullId, notNullDate);
        }

        public async Task ReturnCategoryFromTrashAsync(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                throw new EmptyIdException();

            Guid notNullId = id ?? Guid.Empty;

            await _manager.Repository.SetCategoryDeletionDateAsync(notNullId, null);
        }
    }
}
