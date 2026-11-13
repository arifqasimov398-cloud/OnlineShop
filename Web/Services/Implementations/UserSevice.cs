using Web.Repositories.Interfaces;

namespace Web.Services.Implementations
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Role = dto.Role
            };

            await userRepository.AddAsync(user);
            await userRepository.SaveAsync();

            return MapToDto(user);
        }

        public Task<List<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        private UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }
    }
}