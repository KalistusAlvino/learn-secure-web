using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SecureWeb.Data;
using SecureWeb.Models;
using SecureWeb.ViewModel;

namespace SecureWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUser _userData;

        public AccountController(IUser user)
        {
            _userData = user;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userData.ChangePassword(
                        changePasswordViewModel.Email,
                        changePasswordViewModel.NewPassword,
                        changePasswordViewModel.OldPassword
                    );
                    if (user != null)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.Error = "Terjadi kesalahan saat mengubah password";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(changePasswordViewModel);
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel registrationViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new Models.User
                    {
                        Email = registrationViewModel.Email,
                        Password = registrationViewModel.Password,
                        RoleId = 1,
                    };
                    _userData.Registration(user);
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(registrationViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {

                var user = new User
                {
                    Email = loginViewModel.Email,
                    Password = loginViewModel.Password,
                };

                var loginUser = _userData.Login(user);

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = loginViewModel.RememberLogin
                    });
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult ConfirmEmail(string email)
        {

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Invalid email.");
            }

            var user = _userData.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (!user.EmailConfirmed)
            {
                user.EmailConfirmed = true;
                _userData.UpdateUser(user);
            }

            return View("EmailConfirmed");
        }
    }
}