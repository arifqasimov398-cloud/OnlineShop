namespace Web.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetByBuyerIdAsync(int buyerId);
        Task AddAsync(Order order);
        Task SaveAsync();
    }
}