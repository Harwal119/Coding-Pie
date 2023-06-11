using CodingPie.Models;
using CodingPie.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodingPie.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController()
        {
            _service = new UserService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _service.Login(model.Email, model.PassWord);
            if(!user.Status)
            {
                return View();
            }
            /*HttpContext.Session.SetString("name" , user.Name);
            HttpContext.Session.SetString("email" , user.Email);*/

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //var authenticationProperty = new AuthenticationProperties();

            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

            HttpContext.SignInAsync(claimsPrincipal);
            
            return RedirectToAction("Pies","Pie");
        }
        
        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}