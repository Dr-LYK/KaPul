using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Controllers
{
    [Route("")]
    public class HomeController: Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Kapul API");
        }
    }
}
