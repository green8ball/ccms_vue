using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using server.Data;
using server.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json.Serialization;

namespace server.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class ServerTimeController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbContext _appDbContext;

        public ServerTimeController(UserManager<AppUser> userManager, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(new {
                serverTime = DateTime.Now.ToString("dddd MMM dd, yyyy  HH:mm:ss") + " EST"
            });
        }
    }
}
