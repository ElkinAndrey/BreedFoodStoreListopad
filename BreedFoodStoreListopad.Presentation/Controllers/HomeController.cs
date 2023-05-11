using BreedFoodStoreListopad.Infrastructure.ViewModel;
using BreedFoodStoreListopad.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BreedFoodStoreListopad.Presentation.Controllers
{
	[ApiController]
	[Route("api")]
	public class HomeController : ControllerBase
	{
		/// <summary>
		/// Сервис для работы с приложением
		/// </summary>
		private IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }

        /// <summary>
        /// Добавление новой категории
        /// </summary>
        /// <param name="model">Параметры добавления</param>
        /// <returns></returns>
        [HttpPost]
		[Route("AddCategory")]
		public async Task<IActionResult> AddCategoryAsync([FromForm]AddCategoryViewModel model)
		{
            try
            {
                await _service.AddCategoryAsync(
                    model.Name,
                    model.File?.FileName, 
                    model.File?.ContentType,
                    model.File?.OpenReadStream());

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
		}

        /// <summary>
        /// Получить срез категорий
        /// </summary>
        /// <param name="model">Параметры среза</param>
        /// <returns>Категории</returns>
        [HttpPost]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync(GetCategoriesViewModel model)
        {
            try
            {
                var categories =  await _service.GetCategoriesAsync(model.Start, model.Length);

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить срез удаленных категорий
        /// </summary>
        /// <param name="model">Параметры среза</param>
        /// <returns>Удаленные категории</returns>
        [HttpPost]
        [Route("GetCategoriesInTrash")]
        public async Task<IActionResult> GetCategoriesInTrashAsync(GetCategoriesViewModel model)
        {
            try
            {
                var categories = await _service.GetCategoriesInTrashAsync(model.Start, model.Length);

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить картинку по пути
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="name">Имя</param>
        /// <param name="file">Название картинки</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetImage/{folder}/{name}/{file}")]
        public async Task<IActionResult> GetImageAsync(string folder, string name, string file)
        {
            try
            {
                var image =  await _service.GetImageAsync($"{folder}/{name}/{file}", File);

                return image;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}