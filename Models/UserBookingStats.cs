using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomAndDeskBookingApplication.Models
{
    public class UserBookingStats
    {
        [Key]
        public int StatsId { get; set; }

        [Required]
        public int UserId { get; set; }

        public int TotalBookings { get; set; } = 0;

        public int CompletedBookings { get; set; } = 0;

        public int CancelledBookings { get; set; } = 0;

        public int NoShows { get; set; } = 0;

        public DateTime? LastNoShowDate { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
