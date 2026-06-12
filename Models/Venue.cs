using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http; // Ensures IFormFile resolves cleanly

namespace EventEase.Models
{
    /// <summary>
    /// Represents a transactional physical space entity within the EventEase system.
    /// </summary>
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        [Required(ErrorMessage = "Every beautiful venue needs a name! 🎀")]
        [StringLength(100, ErrorMessage = "That name is a bit too long, keep it under 100 characters.")]
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please tell us where this venue is located.")]
        [Display(Name = "Location")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Don't forget to set a capacity!")]
        [Range(1, 5000, ErrorMessage = "Capacity must be between 1 and 5000.")]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Photo URL")]
        public string? ImageURL { get; set; }

        // This handles the actual file binary stream during the cloud upload process
        [NotMapped]
        [Display(Name = "Upload Venue Photo")]
        public IFormFile? ImageFile { get; set; }

        /// <summary>
        /// Added for Part 3 advanced filtering constraints.
        /// Defaults to true to maintain data compatibility with pre-existing records.
        /// </summary>
        [Required]
        [Display(Name = "Available for Bookings")]
        public bool Availability { get; set; } = true;
    }
}