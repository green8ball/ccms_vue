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

namespace server.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbContext _appDbContext;

        public DashboardController(UserManager<AppUser> userManager, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var employee = await _appDbContext.Employees.Include(c => c.Identity).SingleAsync(c => c.IdentityId == userId.Value);
        
            return new OkObjectResult(new 
            {
                employee.Identity.ADID,
                employee.Identity.ezLMID,
                employee.Identity.Email,
                employee.Identity.FirstName,
                employee.Identity.LastName,
            });
        }
    }
}