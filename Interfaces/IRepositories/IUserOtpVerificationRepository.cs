using System.Threading.Tasks;
using RoomDeskBooking.Domain.Entities;
using RoomDeskBooking.Domain.Enums;

namespace RoomDeskBooking.Interfaces.IRepositories
{
    public interface IUserOtpVerificationRepository
    {
        Task<UserOtpVerification?> GetLatestOtpAsync(int userId, OtpType type);
        Task AddOtpAsync(UserOtpVerification otp);
        Task<bool> VerifyOtpAsync(int userId, string otp, OtpType type);
        Task DeleteExpiredOtpsAsync();
        Task SaveChangesAsync();
    }
}
