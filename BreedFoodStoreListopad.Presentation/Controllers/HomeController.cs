using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BreedFoodStoreListopad.Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HomeController : ControllerBase
	{
		public class A
		{

			public string Name { get; set; }
			public IFormFile File { get; set; }

        }

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> Get([FromForm]A file)
		{
            FakeObjectStorage fakeObjectStorage = new FakeObjectStorage();
			await fakeObjectStorage.AddFile("qwerty", file.File.FileName, file.File.ContentType, file.File.OpenReadStream());

            return Ok();
		}
	}
}