using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomAndDeskBookingApplication.Models
{
    public class UserNotification
    {

        [Key]
        public int NotificationId { get; set; }

        [Required]
        public int UserId { get; set; }

        public int? BookingId { get; set; }

        [Required]
        public NotificationType NotificationType { get; set; }

        [Required]
        [StringLength(200)]
        public string NotificationSubject { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

        public DateTime? SentAt { get; set; }

        public int? LocationId { get; set; }

        public int? DepartmentId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
