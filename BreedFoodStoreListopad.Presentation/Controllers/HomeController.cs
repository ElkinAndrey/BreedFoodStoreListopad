using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Infrastructure.ViewModel;
using BreedFoodStoreListopad.Persistence.Repositories;
using BreedFoodStoreListopad.Service.Abstractions;
using BreedFoodStoreListopad.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static System.Net.Mime.MediaTypeNames;

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
	}
}