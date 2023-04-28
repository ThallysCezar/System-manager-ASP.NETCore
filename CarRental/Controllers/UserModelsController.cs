using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;
using CarRental.Models;
using CarRental.Services.Interfaces;
using CarRental.Models.ViewModels;
using System.Diagnostics;

namespace CarRental.Controllers
{
    public class UserModelsController : Controller
    {
        private readonly CarRentalContext _context;
        private readonly IUserService _userService;

        public UserModelsController(CarRentalContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
              return _context.Users != null ? 
                          View(await _context.Users.ToListAsync()) :
                          Problem("Entity set 'CarRentalContext.Users'  is null.");
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Login,Email,Profile,Password,DataRegister,DataUpdate")] UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(userModel);
                    TempData["SuccessMessage"] = "User successfully created!";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(userModel);
            }
            catch(Exception ex)
            {
                TempData["ErroMessage"] = $"Oops! We could not create the User, please try again, error detail: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var userModel = await _context.Users.FindAsync(id.Value);
            if (userModel == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var userPasswordModel = new UserPasswordModel
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
                Login = userModel.Login,
                Profile = (Models.Enum.ProfileEnum)userModel.Profile
            };
            return View(userPasswordModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Login,Email,Profile,Password")] UserPasswordModel userPasswordModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var userModel = await _context.Users.FindAsync(userPasswordModel.Id);
                    userModel.Name = userPasswordModel.Name;
                    userModel.Email = userPasswordModel.Email;
                    userModel.Login = userPasswordModel.Login;
                    userModel.Profile = (Models.Enum.ProfileEnum)userPasswordModel.Profile;
                    _ = _context.Update(userModel);
                    TempData["SuccessMessage"] = "User successfully edited!";
                    await _context.SaveChangesAsync();
                }
                catch (ApplicationException e)
                {
                    TempData["ErroMessage"] = $"Oops! We could not edit the Users, please try again, error detail: {e.Message}";
                    return RedirectToAction(nameof(Error), new { message = e.Message });

                }
                return RedirectToAction(nameof(Index));
            }
            TempData["SuccessMessage"] = "User successfully edited!";
            return View(userPasswordModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(userModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'CarRentalContext.Users'  is null.");
            }
            var userModel = await _context.Users.FindAsync(id);
            if (userModel != null)
            {
                _context.Users.Remove(userModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
