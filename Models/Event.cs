﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomAndDeskBookingApplication.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(200)]
        public string EventTitle { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        public int? LocationId { get; set; }

        public int? BuildingId { get; set; }

        public int? FloorId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public byte[]? EventImage { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        [ForeignKey("FloorId")]
        public Floor Floor { get; set; }

        public ICollection<UserNotification> Notifications { get; set; } = new List<UserNotification>();
    }
}
