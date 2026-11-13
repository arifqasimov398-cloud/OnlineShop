using Web.Data;
using Web.Repositories.Interfaces;

namespace Web.Repositories.Implementations
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task<List<Order>> GetByBuyerIdAsync(int buyerId)
        {
            return await context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Product)
                .Where(o => o.BuyerId == buyerId)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await context.Orders.AddAsync(order);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}