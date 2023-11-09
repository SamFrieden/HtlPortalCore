using HtlPortalCore.Common.Enums;
using HtlPortalCore.Models;
using HtlPortalCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HtlPortalCore.WebApi
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService) 
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [ProducesResponseType(200, Type = typeof(string))]
        [HttpPost(Name = "RegisterUserSendToken")]
        [AllowAnonymous]       
        public async Task<ActionResult> RegisterUserSendToken([FromBody] UserRegisterViewModel user)
        {
            await _userService.RegisterPhoneSendEmailVerificationAsync(user);
            return Ok("We have send you Email for Verification.");
        }
    }
}
