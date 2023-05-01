using CarRental.Data;
using CarRental.Models;
using CarRental.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userService.SearchByLogin(loginModel.Login);
                    if (user != null)
                    {
                        if(user.ValidPassword(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["ErroMessage"] = $"Invalid password(s), please try again!";
                    }
                    TempData["ErroMessage"] = $"Invalid username and/or password(s), please try again!";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = $"Oops! We could not Login, please try again, error detail: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
