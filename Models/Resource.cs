﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomAndDeskBookingApplication.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int BuildingId { get; set; }

        [Required]
        public int FloorId { get; set; }

        public bool IsUnderMaintenance { get; set; } = false;

        public int? MinBookingDuration { get; set; } // in minutes

        public int? MaxBookingDuration { get; set; } // in minutes

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        [ForeignKey("FloorId")]
        public Floor Floor { get; set; }

        public Room Room { get; set; }
        public Desk Desk { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
