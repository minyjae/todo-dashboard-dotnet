using Domain;

namespace Application;

public class ListService(IListRepository listRepository) : IListService
{
    public Task<IEnumerable<Lists>> GetByUserIdAsync(Guid userId) =>
        listRepository.GetByUserIdAsync(userId);

    public Task CreateAsync(Guid userId, string title, string? description) =>
        throw new NotImplementedException();

    public Task UpdateAsync(Guid id, string title, string? description) =>
        throw new NotImplementedException();

    public Task DeleteAsync(Guid id) =>
        listRepository.DeleteAsync(id);
}
