using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomAndDeskBookingApplication.Models
{
    public class BookingCheckIn
    {
        [Key]
        public int CheckInId { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required]
        public DateTime CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        // Navigation Properties
        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }
    }
}
