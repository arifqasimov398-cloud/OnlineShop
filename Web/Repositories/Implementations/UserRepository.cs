using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Repositories.Interfaces;

namespace Web.Repositories.Implementations
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}