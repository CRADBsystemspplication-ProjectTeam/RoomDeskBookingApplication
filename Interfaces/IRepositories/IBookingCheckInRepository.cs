using ConferenceRoomAndDeskBookingApplication.Interfaces.IRepositories;
using ConferenceRoomAndDeskBookingApplication.Models;

public interface IBookingCheckInRepository : IRepository<BookingCheckIn>
{
    Task<BookingCheckIn> CheckInAsync(int bookingId);
    Task<BookingCheckIn> CheckOutAsync(int bookingId);
    Task<BookingCheckIn?> GetCheckInByBookingIdAsync(int bookingId);
}