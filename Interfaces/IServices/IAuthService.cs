using System.Threading.Tasks;
using RoomDeskBooking.Domain.DTOs;
using RoomDeskBooking.Domain.Enums;

namespace RoomDeskBooking.Interfaces.IServices
{
    public interface IAuthService
    {
        // Authentication
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto);
        Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto dto);
        Task<bool> ValidateUserCredentialsAsync(string email, string password);

        // Password Management
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<bool> ResetPasswordAsync(string email, string newPassword);

        // OTP Handling
        Task GenerateAndSendOtpAsync(string email, OtpType type);
        Task<bool> VerifyOtpAsync(string email, string otp, OtpType type);

        // Token Management
        Task<string> GenerateJwtTokenAsync(User user);
    }
}
