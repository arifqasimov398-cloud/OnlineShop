namespace Web.Services.Implementations
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateAsync(CreateUserDto dto);
    }
}
