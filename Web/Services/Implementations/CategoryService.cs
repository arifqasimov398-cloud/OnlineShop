using Web.Repositories.Interfaces;

namespace Web.Services.Implementations
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
            public async Task<List<CategoryDto>> GetAllAsync()
            {
                var categories = await categoryRepository.GetAllAsync();
                return categories.Select(c => MapToDto(c)).ToList();
            }

            public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
            {
                var category = new Category
                {
                    Name = dto.Name
                };

                await categoryRepository.AddAsync(category);
                await categoryRepository.SaveAsync();

                return MapToDto(category);
            }

            private CategoryDto MapToDto(Category category)
            {
                return new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }

        public Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            return GetAllAsync();
        }
    }
}

