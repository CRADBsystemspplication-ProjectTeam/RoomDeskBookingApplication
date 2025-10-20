using ConferenceRoomAndDeskBookingApplication.Models;
using ConferenceRoomAndDeskBookingApplication.Enums;

namespace ConferenceRoomAndDeskBookingApplication.Interfaces.IRepositories
{
    public interface IBookingRepository
    {
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<Booking?> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
        Task<IEnumerable<Booking>> GetBookingsByResourceIdAsync(int resourceId);
        Task<IEnumerable<Booking>> GetBookingsByStatusAsync(SessionStatus status);
        Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<bool> IsResourceAvailableAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? excludeBookingId = null);
        Task<Booking> UpdateBookingAsync(Booking booking);
        Task<bool> CancelBookingAsync(int bookingId, string cancellationReason);
        Task<IEnumerable<Booking>> GetNoShowBookingsAsync();
        Task<IEnumerable<Booking>> GetOverdueBookingsAsync();
    }
}