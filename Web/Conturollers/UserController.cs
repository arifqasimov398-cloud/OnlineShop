namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var result = await userService.CreateAsync(dto);
            return StatusCode(201, result);
        }
    }
}