using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/lists")]
public class ListController(IListService listService) : ControllerBase
{
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var lists = await listService.GetByUserIdAsync(userId);
        return Ok(lists);
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await listService.DeleteAsync(id);
        return NoContent();
    }
}
