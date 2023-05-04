using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Models.ViewModels;
using CarRental.Services.Exceptions;
using System.Diagnostics;
using CarRental.Services.Interfaces;
using CarRental.Data;
using CarRental.Filters;

namespace CarRental.Controllers
{
    [PageLogUser]
    public class SellersController : Controller
    {
        private readonly ISellerService _sellerService;
        private readonly IDepartmentService _departmentService;
        private readonly CarRentalContext _context;

        public SellersController(ISellerService sellerService, IDepartmentService departmentService, CarRentalContext context)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,BirthDate,BaseSalary,DepartmentId")] Seller seller)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(seller);
                    TempData["SuccessMessage"] = "Seller successfully created!";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            catch(Exception erro)
            {
                TempData["ErroMessage"] = $"Oops! We could not create the Seller, please try again, error detail: {erro.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
            


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                TempData["SuccessMessage"] = "Seller successfully deleted!";
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                TempData["ErroMessage"] = $"Oops! We could not delete the Seller, please try again, error detail: {e.Message}";
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                TempData["SuccessMessage"] = "Seller successfully edited!";
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
                TempData["SuccessMessage"] = "Seller successfully edited!";
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                TempData["ErroMessage"] = $"Oops! We could not edit the Seller, please try again, error detail: {e.Message}";
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
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
