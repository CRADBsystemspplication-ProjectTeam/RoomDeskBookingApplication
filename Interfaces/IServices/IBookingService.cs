using ConferenceRoomAndDeskBookingApplication.Models;
using ConferenceRoomAndDeskBookingApplication.Enums;

namespace ConferenceRoomAndDeskBookingApplication.Interfaces.IServices
{
    public interface IBookingService
    {
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<Booking?> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<IEnumerable<Booking>> GetBookingsByStatusAsync(SessionStatus status);
        Task<IEnumerable<Booking>> GetBookingsForCalendarAsync(DateTime startDate, DateTime endDate);
        Task<bool> CancelBookingAsync(int bookingId, int userId, string reason);
        Task<bool> ValidateBookingAvailabilityAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? excludeBookingId = null);
        Task<List<string>> GetAlternativeTimeSlotsAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime);
        Task<Dictionary<string, object>> GetBookingAnalyticsAsync(DateTime? startDate = null, DateTime? endDate = null, int? locationId = null);
    }
}