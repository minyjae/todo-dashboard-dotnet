namespace Domain;

public class Lists
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Users User { get; private set; } = null!;

    private Lists() { }

    public static Lists Create(Guid userId, string title, string? description) => new()
    {
        UserId = userId,
        Title = title,
        Description = description
    };
}
