using Application.Commands.Roles.AddUserToRoles;
using Application.Commands.Roles.CreateRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("Api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IMediator _mediator;

    public RolesController(ILogger<AccountController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Create New Role
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    /// <remarks>Only Admin can add new role</remarks>
    [Authorize (Roles = "Admin,User")]
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole(CreateRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    /// <summary>
    /// Assign a role to a user
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [Authorize (Roles = "Admin")]
    [HttpPost("AddUserToRole")]
    public async Task<IActionResult> AddUserToRole(AddUserToRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}