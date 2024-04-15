using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly ExoDbContext _dbContext;
        //public readonly AppUser _user;
        public readonly RoleManager<IdentityRole> _role;
        public readonly UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        

        public AdminController(ExoDbContext dbContext, RoleManager<IdentityRole> role, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) 
        {
            this._dbContext = dbContext;
            this._signInManager = signInManager;
            this._role = role;
            this._userManager = userManager;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> addToAdmin()
        {
            var user = await _userManager.GetUserAsync(User);
            
            await _userManager.AddToRoleAsync(user, "ADMIN");
            await _dbContext.SaveChangesAsync();
            return Ok(user.UserName + "est admin a présent" );
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRole()
        {
            var user = await _userManager.GetUserAsync(User);
            var isAdmin = await _userManager.IsInRoleAsync(user, "ADMIN");
            var isStandard = await _userManager.IsInRoleAsync(user, "STANDARD");
            if(isAdmin)
            {
                return Ok("Is Admin");
            }
            else
            {
                return Ok("is standard");
            }
        }


    }
}
