namespace Domain;

public interface IListRepository
{
    Task<IEnumerable<Lists>> GetByUserIdAsync(Guid userId);
    Task<Lists?> GetByIdAsync(Guid id);
    Task AddAsync(Lists list);
    Task UpdateAsync(Lists list);
    Task DeleteAsync(Guid id);
}
