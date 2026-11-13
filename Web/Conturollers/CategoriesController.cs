
namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var result = await categoryService.CreateAsync(dto);
            return StatusCode(201, result);
        }
    }
}