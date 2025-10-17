using System.Collections.Generic;
using System.Threading.Tasks;
using RoomDeskBooking.Domain.Entities;

namespace RoomDeskBooking.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        // CRUD
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByEmployeeIdAsync(string employeeId);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);

        // Filtering / Querying
        Task<IEnumerable<User>> GetByDepartmentAsync(int departmentId);
        Task<IEnumerable<User>> GetByLocationAsync(int locationId);
        Task<IEnumerable<User>> SearchAsync(string keyword);

        // Utility
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByEmployeeIdAsync(string employeeId);
        Task SaveChangesAsync();
    }
}
