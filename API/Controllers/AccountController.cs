using System.Security.Claims;
using Application.Commands.User.Login;
using Application.Commands.User.Register;
using Application.Commands.User.Update;
using Application.Queries.UserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]

public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IMediator _mediator;
    

    public AccountController(IMediator mediator, ILogger<AccountController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Registered User</returns>
    /// <response code="201">User registered successfully</response>
    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterUser( RegisterUserCommand command)
    {
        var result =  await _mediator.Send(command);
        return Ok(result);
    }
    /// <summary>
    /// Login 
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Generated JWT Token</returns>
    /// <response code="200">User logged in successfully </response>
    
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginUser(LoginUserCommand command)
    {
        var result =  await _mediator.Send(command);
        return Ok(result);
    }
    
    /// <summary>
    /// Get Profile 
    /// </summary>
    /// <returns></returns>
    [ApiConventionMethod(typeof(DefaultApiConventions),
        nameof(DefaultApiConventions.Get))]
    [Authorize]
    [HttpGet("GetProfileInfo")]
    public async Task<IActionResult> GetProfileInfo()
    {
        var result = await _mediator.Send(new GetUserProfileQuery{ Id = GetCurrentUserId() });
        return Ok(result);

    }
    
    /// <summary>
    /// Update Profile 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [ApiConventionMethod(typeof(DefaultApiConventions),
        nameof(DefaultApiConventions.Put))]
    [Authorize]
    [HttpPut("EditProfile")]
    public async Task<IActionResult> EditProfile( UpdateUserCommand command)
    {
        //temp 
        command.Id = GetCurrentUserId();
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    private Guid GetCurrentUserId()
    {
        var identity = User.Identity as ClaimsIdentity;
        var userid = identity?.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;

        return new Guid(userid);
    }
}