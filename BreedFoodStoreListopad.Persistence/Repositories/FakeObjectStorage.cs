using BreedFoodStoreListopad.Persistence.Abstractions;

namespace BreedFoodStoreListopad.Persistence.Repositories
{
    public class FakeObjectStorage : IObjectStorage
    {
        private readonly string rootFolder = "FakeObjectStorageFiles";

        public async Task AddFile(string folder, string fileName, string contentType, Stream stream)
        {
            await Task.Run(() =>
            {
                string fullPath = $"{rootFolder}/{folder}/{fileName}";

                Directory.CreateDirectory($"{rootFolder}/{folder}");

                using (FileStream fileStream = File.Create(fullPath, (int)stream.Length))
                {
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, (int)data.Length);
                    fileStream.Write(data, 0, data.Length);
                }
            });
        }
    }
}
