using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Repositories.Interfaces;

namespace Web.Repositories.Implementations
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        public async Task<List<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Category category)
        {
            await context.Categories.AddAsync(category);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}