using System.Collections.Generic;
using System.Threading.Tasks;
using RoomDeskBooking.Domain.Entities;
using RoomDeskBooking.Domain.DTOs;

namespace RoomDeskBooking.Interfaces.IServices
{
    public interface IUserService
    {
        // User Management (Admin + Employee)
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetUsersByLocationAsync(int locationId);
        Task<IEnumerable<User>> GetUsersByDepartmentAsync(int departmentId);
        Task<IEnumerable<User>> SearchUsersAsync(string keyword);

        // Creation / Update / Deletion
        Task<User> CreateUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(UpdateUserDto dto);
        Task DeleteUserAsync(int userId);

        // Profile Management
        Task<UserProfileDto?> GetProfileAsync(int userId);
        Task UpdateProfileAsync(UpdateProfileDto dto);

        // Utilities
        Task<bool> IsEmailAvailableAsync(string email);
        Task<bool> IsEmployeeIdAvailableAsync(string employeeId);
    }
}
