using CarRental.Models;

namespace CarRental.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> FindAllAsync();
    }
}
