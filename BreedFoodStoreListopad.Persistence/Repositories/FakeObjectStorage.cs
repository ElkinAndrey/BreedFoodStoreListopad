using BreedFoodStoreListopad.Persistence.Abstractions;
using BreedFoodStoreListopad.Persistence.Exceptions;

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

        public async Task AddFile(string path, string contentType, Stream stream)
        {
            await Task.Run(() =>
            {
                string fullPath = $"{rootFolder}\\{path}";

                Directory.CreateDirectory($"{rootFolder}\\{Path.GetDirectoryName(path)}");

                using (FileStream fileStream = File.Create(fullPath, (int)stream.Length))
                {
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, (int)data.Length);
                    fileStream.Write(data, 0, data.Length);
                }
            });
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
