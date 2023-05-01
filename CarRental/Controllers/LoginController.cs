using CarRental.Models;
using CarRental.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        private readonly Helpers.ISession _session;

        public LoginController(IUserService userService, Helpers.ISession session)
        {
            _userService = userService;
            _session = session;
        }
        public IActionResult Index()
        {
            if (_session.SearchUserSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult LogOff()
        {
            _session.UserSessionRemove();

            return RedirectToAction("Index", "Login");
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
                        if (user.ValidPassword(loginModel.Password))
                        {
                            _session.UserSessionCreation(user);
                            TempData["user"] = user.Name;
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
