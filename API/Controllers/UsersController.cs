using Application.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator, ILogger<AccountController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all registered users
    /// </summary>
    /// <returns></returns>
    /// <remarks>Only Admin can get all users</remarks>
    [Authorize(Roles = "Admin")]
    [HttpGet("GetAllUser")]
    public async Task<IActionResult> GetAllUser()
    {
        var result = await _mediator.Send( new GetUsersQuery());
        return Ok(result);
    }
}