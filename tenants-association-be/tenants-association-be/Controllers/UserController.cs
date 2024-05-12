using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.IServices;
using TenantsAssociation.BusinessLogic.Services;
using TenantsAssociation.DataAccess.IRepository;

namespace tenants_association_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<LoginDto> Login(UserDto user)
        {

            var loggedIn = _userService.Login(user);

            if(loggedIn.LoginResult == LoginResult.UserNotFound)
            {
                return Unauthorized();
            }

            return Ok(loggedIn);
        }
        [HttpGet]
        [Route("getalltenants")]
        public ActionResult<List<UserDto>> GetTenants()
        {
            var userDtos= _userService.GetTenants();
            return Ok(userDtos);
           
        }

        [HttpPost]
        [Route("adduser")]
        public async Task AddUser([FromBody] UserDto userDto)
        {
            await _userService.AddUser(userDto);
        }

    }
}
