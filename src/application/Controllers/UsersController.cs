using System;
using System.Net;
using System.Threading.Tasks;
using domain.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult> GetAll([FromServices] IUserService userService)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        return Ok(await userService.GetAll());
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

  }
}