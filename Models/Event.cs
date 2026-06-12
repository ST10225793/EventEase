using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    /// <summary>
    /// Represents a scheduled event transaction linked to a physical venue and categorized by a lookup type.
    /// </summary>
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "An event name is compulsory.")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; } = string.Empty;

        [Required(ErrorMessage = "A calendar scheduling date must be set.")]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Event Description")]
        public string Description { get; set; } = string.Empty;

        // Foreign Key property mapping to Venues Table
        [Required]
        [Display(Name = "Venue ID")]
        public int VenueId { get; set; }

        // Navigation property with Explicit ForeignKey attribute
        [ForeignKey("VenueId")]
        public virtual Venue? Venue { get; set; }

        /// <summary>
        /// Added for Part 3 database normalization requirements.
        /// Establishes the relationship to the newly introduced EventType lookup entity.
        /// </summary>
        [Required(ErrorMessage = "Please assign a specific event category type.")]
        [Display(Name = "Event Type ID")]
        public int EventTypeId { get; set; }

        // Navigation property mapping to the isolated lookup table
        [ForeignKey("EventTypeId")]
        public virtual EventType? EventType { get; set; }
    }
}