using CarRental.Models;

namespace CarRental.Services.Interfaces
{
    public interface IRentalRecordService
    {
        Task<List<RentalRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate);

        Task<List<IGrouping<Department, RentalRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate);
    }
}
