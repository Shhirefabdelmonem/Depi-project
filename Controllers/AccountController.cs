using LisbrarySystem.Models;
using LisbrarySystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LisbrarySystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser>userManager,
            SignInManager<ApplicationUser>signInManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = UserViewModel.Email;
                user.UserName=UserViewModel.Username;
                user.PasswordHash = UserViewModel.Password;
                user.FirstName = UserViewModel.FirstName;
                user.LastName = UserViewModel.LastName;

                IdentityResult result = await userManager.CreateAsync(user, UserViewModel.Password);
                if (result.Succeeded)
                {

                    //assign to role
                    await userManager.AddToRoleAsync(user, "UsersRole");
                    //cookie
                   await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "account");

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View("register",UserViewModel);

        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> SaveLogin(LoginViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user= await userManager.FindByEmailAsync(userViewModel.Email);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, userViewModel.Password);
                    if (found)
                    {
                        await signInManager.SignInAsync(user, userViewModel.RememberMe);
                        return RedirectToAction("AllBooks", "Home");
                    }


                }
                ModelState.AddModelError("", "Email or Password wrong");
            }
            return View("Login", userViewModel);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }
    }
}
