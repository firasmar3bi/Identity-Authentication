using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityAuthentication.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityAuthentication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(ApplicationDbContext context , UserManager<IdentityUser> userManager ,SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // Register =>
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel data)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = data.Email,
                UserName = data.Email,
                PhoneNumber = data.Phone,
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return View(data);
        }

        // Log in =>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel data)
        {
            var result = await signInManager.PasswordSignInAsync(data.Email, data.Password, data.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(data);
        }

    }
}

