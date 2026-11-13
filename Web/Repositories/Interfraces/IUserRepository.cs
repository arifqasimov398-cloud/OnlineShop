namespace Web.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int buyerId);
        Task SaveAsync();
    }
}