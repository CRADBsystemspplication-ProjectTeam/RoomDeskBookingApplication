using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomAndDeskBookingApplication.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
