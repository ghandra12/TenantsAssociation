using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.DataAccess.IRepository;

namespace tenants_association_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<LoginResult> Login(UserDto user)
        {
            var loggedIn = _userService.Login(user);

            if(loggedIn == LoginResult.UserNotFound)
            {
                return Unauthorized();
            }

            return Ok(loggedIn);
        }

    }
}
