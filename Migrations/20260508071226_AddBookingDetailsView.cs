using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventEase.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // This creates the virtual table (View) in Azure
            migrationBuilder.Sql(@"
        CREATE VIEW View_BookingDetails AS
        SELECT 
            b.BookingId,
            b.CustomerName,
            e.EventName,
            e.EventDate,
            v.VenueName,
            v.Location AS VenueLocation,
            v.Capacity AS MaxGuests
        FROM Bookings b
        JOIN Events e ON b.EventId = e.EventId
        JOIN Venues v ON b.VenueId = v.VenueId;
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // This removes it if you ever need to undo this step
            migrationBuilder.Sql("DROP VIEW View_BookingDetails;");
        }
    }
}
