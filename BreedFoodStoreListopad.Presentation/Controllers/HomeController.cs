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
			return Ok("Листопад");
		}
	}
}