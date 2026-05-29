namespace Domain;

public class Users
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; private set; } = string.Empty;
    public string HashedPassword { get; private set; } = string.Empty;
    public ICollection<Lists> Lists { get; private set; } = new List<Lists>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    private Users() { }

    public static Users Create(string email, string hashedPassword) => new()
    {
        Email = email,
        HashedPassword = hashedPassword
    };
}
