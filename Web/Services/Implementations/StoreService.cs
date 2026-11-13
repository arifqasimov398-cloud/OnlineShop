using Web.Repositories.Interfaces;
using Web.Services.Interfaces;

namespace Web.Services.Implementations
{
    public class StoreService(Web.Repositories.Interfaces.IStoreRepository storeRepository, IUserRepository userRepository) : IStoreService
    {
        public async Task<List<StoreDto>> GetAllAsync()
        {
            var stores = await storeRepository.GetAllAsync();
            return stores.Select(s => MapToDto(s)).ToList();
        }

        public async Task<StoreDto?> CreateAsync(CreateStoreDto dto)
        {
            var seller = await userRepository.GetByIdAsync(dto.SellerId);

            if (seller == null || seller.Role != UserRole.Seller)
                return null;

            var store = new Store
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await storeRepository.AddAsync(store);
            await storeRepository.SaveAsync();

            store.Seller = seller;

            return MapToDto(store);
        }

        private StoreDto MapToDto(Store store)
        {
            return new StoreDto
            {
                Id = store.Id,
                Name = store.Name,
                Description = store.Description,
                SellerName = store.Seller.FullName
            };
        }

        public Task<StoreDto?> GetByIdAsync(int id)
        {
            return GetByIdInternalAsync(id);
        }

        private async Task<StoreDto?> GetByIdInternalAsync(int id)
        {
            var store = await storeRepository.GetByIdAsync(id);
            return store == null ? null : MapToDto(store);
        }
    }
}