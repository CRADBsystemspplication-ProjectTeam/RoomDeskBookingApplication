using ConferenceRoomAndDeskBookingApplication.Models;

namespace ConferenceRoomAndDeskBookingApplication.Interfaces.IRepositories
{
    public interface IBookingCheckInRepository
    {
        Task<BookingCheckIn> CheckInAsync(int bookingId);
        Task<BookingCheckIn> CheckOutAsync(int bookingId);
        Task<BookingCheckIn?> GetCheckInByBookingIdAsync(int bookingId);
    }
}