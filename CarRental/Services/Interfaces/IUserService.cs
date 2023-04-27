using CarRental.Models;

namespace CarRental.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> FindAllAsync();
        Task InsertAsync(UserModel obj);
        //Task<UserModel> FindByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(UserModel obj);
    }
}
