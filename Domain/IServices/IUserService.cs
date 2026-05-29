namespace Domain;

public interface IUserService
{
    Task<Users?> GetByIdAsync(Guid id);
    Task CreateAsync(string email, string password);
    Task<string?> LoginAsync(string email, string password);
}
