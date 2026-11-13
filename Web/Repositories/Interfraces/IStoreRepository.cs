namespace Web.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(int id);
        Task AddAsync(Store store);
        Task SaveAsync();
    }
}