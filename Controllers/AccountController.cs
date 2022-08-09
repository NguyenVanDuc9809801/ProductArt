using Main_project.Dtos;
using Main_project.Models;
using Main_project.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Main_project.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UserService _userService;

        public AccountController(UserManager<User> userManager,
                                    SignInManager<User> signInManager,
                                    UserService userService
                                    )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDtos loginDtos)
        {

            if (_signInManager.IsSignedIn(User)) return Redirect("Index");
            var result = await _signInManager.PasswordSignInAsync(
               loginDtos.Email,
               loginDtos.Password,
               true,
               true
            );
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDtos registerDtos)
        {
            if (registerDtos.Password != registerDtos.ConfirmPassword)
            {
                return View();
            }
            var user = new User { UserName = registerDtos.Email, Email = registerDtos.Email };
            var result = await _userManager.CreateAsync(user, registerDtos.Password);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> UpdateInfo()
        {
            var UserId = _userManager.GetUserId(User);
            var user = await _userService.GetUserInfoIdAsync(UserId);
            return View(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateInfo(InfoUpdateDtos info)
        {
            var UserId = _userManager.GetUserId(User);
            await _userService.UpdateUserAsync(info,UserId);

            return RedirectToAction("Index", "Home");

        }
    }
}