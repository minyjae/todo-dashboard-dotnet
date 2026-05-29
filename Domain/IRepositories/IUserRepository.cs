namespace Domain;

public interface IUserRepository
{
    Task<Users?> GetByIdAsync(Guid id);
    Task<Users?> GetByEmailAsync(string email);
    Task AddAsync(Users user);
}
