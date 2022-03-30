using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserSerivice _userSerivice;

    public UserController(IUserSerivice _userSerivice)
    {
        this._userSerivice = _userSerivice;
    }
    
    //get username with username...
    [HttpGet]
    [Route("{username}")]
    public async Task<ActionResult<User>> GetUserAsync([FromRoute] string username)
    {
        try
        {
            User user = await _userSerivice.GetUserAsync(username);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}