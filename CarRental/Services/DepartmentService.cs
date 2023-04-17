using CarRental.Data;
using CarRental.Models;
using CarRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace CarRental.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CarRentalContext _context;

        public DepartmentService(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
