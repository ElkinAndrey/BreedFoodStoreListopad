using BreedFoodStoreListopad.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BreedFoodStoreListopad.Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		[Route("[action]")]
		public IActionResult Get()
		{
			Category category = new Category("1", "2.jpg");
			category.Name = "2";
			category.FileName = "3";
			return Ok(category);
		}
	}
}