namespace Web.Services.Interfaces
{
    public interface IStoreService
    {
        Task<List<StoreDto>> GetAllAsync();
        Task<StoreDto?> GetByIdAsync(int id);
        Task<StoreDto?> CreateAsync(CreateStoreDto dto);
    }
}
    
