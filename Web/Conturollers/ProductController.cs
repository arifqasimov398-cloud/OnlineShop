using Web.Services.Interfaces;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductFilterDto filter)
        {
            var result = await productService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await productService.GetByIdAsync(id);

            if (result == null)
                return NotFound("Məhsul tapılmadı");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var result = await productService.CreateAsync(dto);

            if (result == null)
                return NotFound("Mağaza və ya kateqoriya tapılmadı");

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}