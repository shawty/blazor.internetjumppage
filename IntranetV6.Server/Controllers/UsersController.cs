using IntranetV6.Server.Services;
using IntranetV6.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntranetV6.Server.Controllers
{
  [Route("api/[controller]")]
  public class UsersController : Controller
  {
    private Users _users;

    public UsersController(Users users)
    {
      _users = users;
    }

    [HttpGet("[action]")]
    public IEnumerable<User> All()
    {
      return _users.GetAll();
    }

    [HttpGet("[action]/{id}")]
    public User Get(int id)
    {
      return _users.GetUser(id);
    }

  }
}
