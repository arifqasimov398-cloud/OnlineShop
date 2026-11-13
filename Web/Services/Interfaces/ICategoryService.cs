namespace Web.Services.Implementations
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        
    }
}
