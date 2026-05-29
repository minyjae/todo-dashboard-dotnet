using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await userService.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Create([FromBody] CreateUserDtos dto)
    {
        await userService.CreateAsync(dto.Email, dto.Password);
        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        var token = await userService.LoginAsync(dto.Email, dto.Password);
        return token is null ? Unauthorized() : Ok(new { token });
    }
}
