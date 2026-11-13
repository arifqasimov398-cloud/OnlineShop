using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Repositories.Interfaces;

namespace Web.Repositories.Implementations
{
    public class StoreRepository(AppDbContext context) : IStoreRepository
    {
        public async Task<List<Store>> GetAllAsync()
        {
            return await context.Stores
                .Include(s => s.Seller)
                .ToListAsync();
        }

        public async Task<Store?> GetByIdAsync(int id)
        {
            return await context.Stores
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Store store)
        {
            await context.Stores.AddAsync(store);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
