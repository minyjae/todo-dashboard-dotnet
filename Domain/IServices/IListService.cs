namespace Domain;

public interface IListService
{
    Task<IEnumerable<Lists>> GetByUserIdAsync(Guid userId);
    Task CreateAsync(Guid userId, string title, string? description);
    Task UpdateAsync(Guid id, string title, string? description);
    Task DeleteAsync(Guid id);
}
