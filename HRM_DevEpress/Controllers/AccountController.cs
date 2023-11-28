using HRM_DevEpress.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HRM.Web.Entities;

namespace HRM_DevEpress.Controllers
{
    public class AccountController : Controller
    {
        private readonly HrmTestContext _db_context;

       
        public AccountController(HrmTestContext db_context)
        {
            _db_context = db_context;
        }



        public IActionResult Login(string ReturnUrl = "")
        {
            Login objLoginModel = new Login();
            objLoginModel.ReturnUrl = ReturnUrl;
            return View(objLoginModel);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login objLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = _db_context.Logins.Where(x => x.UserName == objLoginModel.UserName && x.Password == objLoginModel.Password).FirstOrDefault();
                if (user != null)
                {
                  
                    var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role),
                    };
                  
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                 
                    var principal = new ClaimsPrincipal(identity);
                        
                 
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = objLoginModel.RememberLogin
                    });
                    return LocalRedirect(objLoginModel.ReturnUrl);
                }
                else
                {
                    ViewBag.Message = "Sai UserName hoặc Password";
                    return View(user);
                }
            }
            return View(objLoginModel);
        }


        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return RedirectToAction("Login","Account");
        }

    }
}
