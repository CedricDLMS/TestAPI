using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientAuth : ControllerBase
    {
        public readonly ExoDbContext dbContext;
        public readonly UserManager<AppUser> userManager;
        public readonly RoleManager<IdentityRole> roleManager;
        public readonly SignInManager<AppUser> signInManager;
        public ClientAuth(ExoDbContext _dbContext, UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = _userManager;
            this.dbContext = _dbContext;
            this.roleManager = _roleManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUser user, string password)
        {
            var user1 = new AppUser { Email = user.Email, UserName = user.Email };
            var result = await userManager.CreateAsync(user1, password);
            return Ok(result);
        }

    }
}
