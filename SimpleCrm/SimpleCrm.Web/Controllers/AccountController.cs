using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleCrm.Web.Models.Account;
using System.Threading.Tasks;

namespace SimpleCrm.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CrmUser> userManager;
        private readonly SignInManager<CrmUser> signInManager;

        public AccountController(UserManager<CrmUser> userManager, 
            SignInManager<CrmUser> signInManager
            )
        { // injection is done in the "constructor" method of the class
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
         
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(
            RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            { // model is valid, DataAnnotation validators have passed
                var user = new CrmUser
                {
                    UserName = model.UserName,
                    DisplayName = model.DisplayName,
                    Email = model.UserName
                };
                var CreateResult = await userManager.CreateAsync(user, model.Password);
                if (CreateResult.Succeeded)
                {
                    //TODO: user is created, let's log them in and redirect
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                //TODO: failed to create, let's tell the user why and let them fix it 
                foreach (var result in CreateResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, result.Description);
                }
                // return NoContent(); // TODO: validate model, register the user remove this line when done
            }
            return View(); // show the view again with validation errors highlighted
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(
                  model.UserName, model.Password, model.RememberMe, false);
                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                //TODO: handle errors in login
                ModelState.AddModelError("", "Login Failed");
            }
            return View();
        }
    }  
}
