using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    public class Booking
    {
        [Required(ErrorMessage = "Please enter the customer's name 🎀")]
        public string CustomerName { get; set; }

        public int BookingId { get; set; }
        public int EventId { get; set; }
        public int VenueId { get; set; }

        [Required(ErrorMessage = "Date is required!")]
        public DateTime BookingDate { get; set; }

        public Event? Event { get; set; }
        public Venue? Venue { get; set; }
    }
}
