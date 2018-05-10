using Kapul.Common.Commands;
using Kapul.Services.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Identity.Controllers
{
    [Route("")]
    public class AccountController: Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
        {
            return Json(await _userService.LoginAsync(command.Email, command.Password));
        }
    }
}
