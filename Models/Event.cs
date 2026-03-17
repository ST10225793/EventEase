using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        // Foreign Key property
        [Required]
        public int VenueId { get; set; }

        // Navigation property with ForeignKey attribute
        [ForeignKey("VenueId")]
        public virtual Venue? Venue { get; set; }
    }
}