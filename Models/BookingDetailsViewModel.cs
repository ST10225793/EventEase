namespace EventEase.Models
{
    public class BookingDetailsViewModel
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string VenueName { get; set; }
        public string VenueLocation { get; set; }
        public int MaxGuests { get; set; }

        public string EventCategory { get; set; } = string.Empty;

        // ADD THIS LINE FOR THE VENUE ACCESSIBILITY INTEGRATION 🚦
        public bool IsVenueAvailable { get; set; }
    }
}
