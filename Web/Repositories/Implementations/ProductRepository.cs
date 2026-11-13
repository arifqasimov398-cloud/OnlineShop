using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Repositories.Interfaces;

namespace Web.Repositories.Implementations
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<List<Product>> GetAllAsync(ProductFilterDto filter)
        {
            var query = context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(p => p.Name.Contains(filter.Name));

            if (filter.CategoryId != null)
                query = query.Where(p => p.CategoryId == filter.CategoryId);

            if (filter.MinPrice != null)
                query = query.Where(p => p.Price >= filter.MinPrice);

            if (filter.MaxPrice != null)
                query = query.Where(p => p.Price <= filter.MaxPrice);

            return await query.ToListAsync();
        }

        public async Task<List<Product>> GetByStoreIdAsync(int storeId)
        {
            return await context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .Where(p => p.StoreId == storeId)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}