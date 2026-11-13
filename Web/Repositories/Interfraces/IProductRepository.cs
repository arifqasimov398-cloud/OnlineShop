namespace Web.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductFilterDto filter);
        Task<List<Product>> GetByStoreIdAsync(int storeId);
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task SaveAsync();
    }
}