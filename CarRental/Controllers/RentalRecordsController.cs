using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;
using CarRental.Services.Interfaces;

namespace CarRental.Controllers
{
    public class RentalRecordsController : Controller
    {
        private readonly CarRentalContext _context;

        private readonly IRentalRecordService _recordService;

        public RentalRecordsController(CarRentalContext context, IRentalRecordService recordService)
        {
            _context = context;
            _recordService = recordService;
        }

        // GET: RentalRecords1
        public async Task<IActionResult> Index()
        {
            return _context.RentalRecord != null ?
                        View(await _context.RentalRecord.ToListAsync()) :
                        Problem("Entity set 'CarRentalContext.RentalRecord'  is null.");
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _recordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _recordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
