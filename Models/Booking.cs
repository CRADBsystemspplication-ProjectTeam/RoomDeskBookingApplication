using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomAndDeskBookingApplication.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ResourceId { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        [StringLength(200)]
        public string MeetingName { get; set; }

        [StringLength(500)]
        public string? Purpose { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Confirmed;

        // Check-in/Check-out tracking
        public DateTime? ActualCheckInTime { get; set; }

        public DateTime? ActualCheckOutTime { get; set; }

        // Reminder flags
        public bool EntryReminderSent { get; set; } = false;

        public bool CheckInReminderSent { get; set; } = false;

        public bool ExitReminderSent { get; set; } = false;

        public bool OverdueReminderSent { get; set; } = false;

        // Cancellation
        [StringLength(500)]
        public string? CancellationReason { get; set; }

        public DateTime? CancelledAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ResourceId")]
        public Resource Resource { get; set; }

        public BookingCheckIn CheckIn { get; set; }
        public ICollection<UserNotification> Notifications { get; set; } = new List<UserNotification>();
    }
}
