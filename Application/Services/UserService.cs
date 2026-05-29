using Domain;
using Utils;

namespace Application;

public class UserService(IUserRepository userRepository, IConfiguration config) : IUserService
{
    public Task<Users?> GetByIdAsync(Guid id) =>
        userRepository.GetByIdAsync(id);

    public async Task CreateAsync(string email, string password)
    {
        var user = Users.Create(email, PasswordHelper.Hash(password));
        await userRepository.AddAsync(user);
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
        var user = await userRepository.GetByEmailAsync(email);
        if (user is null) return null;

        if (user.HashedPassword != PasswordHelper.Hash(password)) return null;

        return JwtHelper.GenerateToken(user, config);
    }
}
