using BreedFoodStoreListopad.Persistence.Abstractions;
using BreedFoodStoreListopad.Persistence.Exceptions;
using System.IO;

namespace BreedFoodStoreListopad.Persistence.Repositories
{
    /// <summary>
    /// Фейковое объектное хранилище, находящееся прямо на сервере
    /// </summary>
    public class FakeObjectStorage : IObjectStorage
    {
        /// <summary>
        /// Главная папка, в которой лежат все файлы
        /// </summary>
        private readonly string rootFolder = "FakeObjectStorageFiles";

        public async Task AddFileAsync(string path, string contentType, Stream stream)
        {

            string fullPath = $"{rootFolder}\\{path}";

            Directory.CreateDirectory($"{rootFolder}\\{Path.GetDirectoryName(path)}");

            using (FileStream fileStream = File.Create(fullPath, (int)stream.Length))
            {
                byte[] data = new byte[stream.Length];
                var readTask = stream.ReadAsync(data, 0, (int)data.Length);
                var writeTask = fileStream.WriteAsync(data, 0, data.Length);
                await readTask;
                await writeTask;
            }
        }

        public async Task DeleteFolderAsync(string folderPath)
        {
            await Task.Run(() => Directory.Delete($"{rootFolder}\\{folderPath}", true));
        }

        public async Task<Stream> GetFileAsync(string path)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return new FileStream($"{rootFolder}\\{path}", FileMode.Open);
                }
                catch (DirectoryNotFoundException ex)
                {
                    throw new CouldNotFindFolderException();
                }
                catch (FileNotFoundException ex)
                {
                    throw new CouldNotFindFolderException();
                }
            });
        }
    }
}
