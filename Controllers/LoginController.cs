using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnimeAratoBackend.Data;
using AnimeAratoBackend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeAratoBackend.Controllers
{
    public class LoginController : Controller
    {
        public UserManager userManager { get; set; }
        public LoginController(UserManager userManager)
        {
            this.userManager = userManager;
        }
        // GET: /<controller>/
        [HttpPost(),Route("SignIn")]
        public async Task<IActionResult> SignInUser([FromForm]User user)
        {
            var username = user.UserName.ToLower();
            if (!userManager.Users.ContainsKey(username)) {
                return BadRequest("User Not Found");
            }
            var password = this.userManager.Users[username].Password;
            if (user.Password == password)
            {
                await SignUser(username);
                return Redirect("/newentry");
            }
           
               return BadRequest("Password Incorrect");
           
        
        }
        [Route("SignOut")]
        public async Task<RedirectResult> SignOutUser()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login");
        }
        public IActionResult Index()
        {
          
            return View();
        }

        public async Task SignUser(string userName)
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier,userName),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim("UserName",userName)

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.NameIdentifier, ClaimTypes.Role);
            var principle = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principle);
        }

    }
}
