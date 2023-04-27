using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.EventAgg;

namespace puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime BookingDate { get; set; }
        public string RentalDetails { get; set; }
    }
}
