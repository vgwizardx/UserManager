
using Microsoft.AspNetCore.Mvc;
using Domain.Common.DTOs;
using Domain.Interfaces.DTOs;
using Domain.Interfaces.Services;

namespace UserManager.Application.API.Controllers;

/// <summary>
/// Controller for handling user-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ILogger<UserController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="service">The user service instance.</param>
    public UserController(ILogger<UserController> logger, IUserService service)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <returns>A list of users.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _service.GetAsync();
        return Ok(users);
    }

    /// <summary>
    /// Retrieves a specific user by their unique identifier.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <returns>The user if found; otherwise, a 404 Not Found.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _service.GetAsync(id);
        return user == null ? NotFound() : Ok(user);
    }

    /// <summary>
    /// Adds a new user to the system.
    /// </summary>
    /// <remarks>
    /// This endpoint creates a new user with the given details. If successful, it returns
    /// a 201 Created status with the newly created id and email in the response body.
    /// Additionally, the response includes a Location header containing the URL to retrieve the complete created user info.
    /// In case of failure, a 400 Bad Request or 500 Internal Server Error is returned.
    /// </remarks>
    /// <param name="request">The user creation request data.</param>
    /// <returns>A 201 Created response with the created user, or an error status code.</returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddUserRequest request)
    {
        var user = await _service.AddUserAsync(request);
        
        if (user != null)
        {
            var getUrl = Url.Action(nameof(Get), new { id = user.Id });

            Response.Headers["Location"] = getUrl;

            return Created(getUrl, user);
        }

        return BadRequest();
    }

    /// <summary>
    /// Updates an existing user's data.
    /// </summary>
    /// <remarks>
    /// This endpoint updates a user's details based on the provided unique identifier and the update request data.
    /// On successful update, it returns a 200 OK status with the updated user data in the response body.
    /// Additionally, a Location header is included in the response, containing the URL to retrieve the updated user.
    /// If the specified user is not found, a 404 Not Found status is returned.
    /// </remarks>
    /// <param name="id">The unique identifier of the user to be updated.</param>
    /// <param name="request">The user update request data.</param>
    /// <returns>A 200 OK response with the updated user, or an error status code.</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserRequest request)
    {
        var user = await _service.UpdateUserAsync(id, request);
        
        if (user != null)
        {
            var getUrl = Url.Action(nameof(Get), new { id = user.Id });

            Response.Headers["Location"] = getUrl;

            return Ok(user);
        }

        return NotFound();
    }
}
