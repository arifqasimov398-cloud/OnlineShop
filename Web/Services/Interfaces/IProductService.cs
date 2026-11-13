namespace Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync(ProductFilterDto filter);
        Task<List<ProductDto>?> GetByStoreIdAsync(int storeId);
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto?> CreateAsync(CreateProductDto dto);
    }
}