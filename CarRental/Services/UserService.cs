using CarRental.Data;
using CarRental.Models;
using CarRental.Services.Exceptions;
using CarRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class UserService : IUserService
    {

        private readonly CarRentalContext _context;

        public UserService(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> FindAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task InsertAsync(UserModel obj)
        {
            obj.DataRegister = DateTime.Now;
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        //public async Task<UserModel> FindByIdAsync(int id)
        //{
        //    return await _context.Users.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        //}

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Users.FindAsync(id);
                _context.Users.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        public async Task UpdateAsync(UserModel obj)
        {
            bool hasAny = await _context.Users.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                obj.DataUpdate = DateTime.Now;
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}

