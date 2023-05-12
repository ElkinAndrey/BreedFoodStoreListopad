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

        private void TimeStop()
        {
            Thread.Sleep(1000);
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
            TimeStop();
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
            TimeStop();
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
            TimeStop();
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
            TimeStop();
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

        /// <summary>
        /// ����������� ��������� � �������
        /// </summary>
        /// <param name="model">��������� �����������</param>
        /// <returns></returns>
        [HttpPost]
        [Route("MoveCategoryToTrash")]
        public async Task<IActionResult> MoveCategoryToTrashAsync(MoveToTrashViewModel model)
        {
            TimeStop();
            try
            {
                await _service.MoveCategoryToTrashAsync(model.Id, model.MoveDate);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// ������� ��������� �� ������� ��������� ���������
        /// </summary>
        /// <param name="id">Id ���������</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ReturnCategoryFromTrash/{id}")]
        public async Task<IActionResult> ReturnCategoryFromTrashAsync(Guid? id)
        {
            TimeStop();
            try
            {
                await _service.ReturnCategoryFromTrashAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}