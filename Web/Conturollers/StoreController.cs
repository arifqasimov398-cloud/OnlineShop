using Web.Services.Interfaces;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController(IStoreService storeService, IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IStoreService storeService1 = storeService;
            var result = await storeService1.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var result = await productService.GetByStoreIdAsync(id);

            if (result == null)
                return NotFound("Mağaza tapılmadı");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStoreDto dto)
        {
            var result = await storeService.CreateAsync(dto);

            if (result == null)
                return NotFound("Satıcı tapılmadı");

            return StatusCode(201, result);
        }
    }
}