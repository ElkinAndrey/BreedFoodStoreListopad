using Microsoft.AspNetCore.Http;

namespace BreedFoodStoreListopad.Infrastructure.ViewModel
{
    /// <summary>
    /// Вью модель для добавления новой категории
    /// </summary>
    public class AddCategoryViewModel
    {
        /// <summary>
        /// Название новой категории
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Картинка новой категории
        /// </summary>
        public IFormFile? File { get; set; }
    }
}
