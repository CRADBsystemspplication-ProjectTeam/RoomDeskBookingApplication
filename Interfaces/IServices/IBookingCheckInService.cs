using ConferenceRoomAndDeskBookingApplication.Models;

namespace ConferenceRoomAndDeskBookingApplication.Interfaces.IServices
{
    public interface IBookingCheckInService
    {
        Task<BookingCheckIn> CheckInAsync(int bookingId, int userId);
        Task<bool> CanCheckInAsync(int bookingId);
        Task<BookingCheckIn> CheckOutAsync(int bookingId, int userId);
        Task<bool> CanCheckOutAsync(int bookingId);
        Task<BookingCheckIn?> GetCheckInStatusAsync(int bookingId);
        Task ProcessNoShowBookingsAsync();
        Task ProcessOverdueCheckoutsAsync();
    }
}