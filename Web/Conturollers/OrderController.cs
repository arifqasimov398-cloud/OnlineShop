using Web.Services.Interfaces;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            try
            {
                var result = await orderService.CreateAsync(dto);
                return StatusCode(201, result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);      
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);    
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            try
            {
                var result = await orderService.GetByBuyerIdAsync(userId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}