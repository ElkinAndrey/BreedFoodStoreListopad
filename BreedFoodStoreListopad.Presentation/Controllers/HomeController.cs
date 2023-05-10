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
    }
}