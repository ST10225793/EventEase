using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    /// <summary>
    /// Represents the lookup table for predefined event categories.
    /// Normalizes event categorization to eliminate update anomalies and ensure data integrity.
    /// </summary>
    public class EventType
    {
        [Key]
        [Display(Name = "Event Type ID")]
        public int EventTypeId { get; set; }

        [Required(ErrorMessage = "An event category name is compulsory.")]
        [StringLength(50, ErrorMessage = "Category name must be under 50 characters.")]
        [Display(Name = "Event Category")]
        public string Name { get; set; } = string.Empty;
    }
}