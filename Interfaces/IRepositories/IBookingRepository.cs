using ConferenceRoomAndDeskBookingApplication.Enums;
using ConferenceRoomAndDeskBookingApplication.Interfaces.IRepositories;
using ConferenceRoomAndDeskBookingApplication.Models;

public interface IBookingRepository : IRepository<Booking>
{
    Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
    Task<IEnumerable<Booking>> GetBookingsByResourceIdAsync(int resourceId);
    Task<IEnumerable<Booking>> GetBookingsByStatusAsync(SessionStatus status);
    Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<bool> IsResourceAvailableAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? excludeBookingId = null);
    Task<bool> CancelBookingAsync(int bookingId, string cancellationReason);
    Task<IEnumerable<Booking>> GetNoShowBookingsAsync();
    Task<IEnumerable<Booking>> GetOverdueBookingsAsync();
}