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
		/// ������ ��� ������ � �����������
		/// </summary>
		private IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }

        /// <summary>
        /// ���������� ����� ���������
        /// </summary>
        /// <param name="model">��������� ����������</param>
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
        /// �������� ���� ���������
        /// </summary>
        /// <param name="model">��������� �����</param>
        /// <returns>���������</returns>
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
        /// �������� ���� ��������� ���������
        /// </summary>
        /// <param name="model">��������� �����</param>
        /// <returns>��������� ���������</returns>
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
        /// �������� �������� �� ����
        /// </summary>
        /// <param name="folder">�����</param>
        /// <param name="name">���</param>
        /// <param name="file">�������� ��������</param>
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