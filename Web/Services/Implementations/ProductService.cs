using Web.Repositories.Interfaces;
using Web.Services.Interfaces;

namespace Web.Services.Implementations
{
    public class ProductService(
        IProductRepository productRepository,
        Web.Repositories.Interfaces.IStoreRepository storeRepository,
        ICategoryRepository categoryRepository) : IProductService
    {
        public async Task<List<ProductDto>> GetAllAsync(ProductFilterDto filter)
        {
            var products = await productRepository.GetAllAsync(filter);
            return products.Select(p => MapToDto(p)).ToList();
        }

        public async Task<List<ProductDto>?> GetByStoreIdAsync(int storeId)
        {
            var store = await storeRepository.GetByIdAsync(storeId);
            if (store == null)
                return null;

            var products = await productRepository.GetByStoreIdAsync(storeId);
            return products.Select(p => MapToDto(p)).ToList();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
                return null;

            return MapToDto(product);
        }

        public async Task<ProductDto?> CreateAsync(CreateProductDto dto)
        {
            var store = await storeRepository.GetByIdAsync(dto.StoreId);
            var category = await categoryRepository.GetByIdAsync(dto.CategoryId);

            if (store == null || category == null)
                return null;

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                StoreId = dto.StoreId,
                CategoryId = dto.CategoryId
            };

            await productRepository.AddAsync(product);
            await productRepository.SaveAsync();

            product.Store = store;
            product.Category = category;

            return MapToDto(product);
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                StoreName = product.Store.Name,
                CategoryName = product.Category.Name
            };
        }
    }
}