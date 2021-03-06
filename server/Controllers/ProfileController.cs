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

namespace server.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbContext _appDbContext;

        public ProfileController(UserManager<AppUser> userManager, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        // GET api/profile/me
        [HttpGet]
        public async Task<IActionResult> Me()
        {
            // retrieve the user info
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var customer = await _appDbContext.Employees.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            return new OkObjectResult(new
            {
                customer.Identity.FirstName,
                customer.Identity.LastName,
                customer.Identity.ADID,
                customer.Identity.Email,
                customer.Identity.ezLMID
            });
        }
    }
}
