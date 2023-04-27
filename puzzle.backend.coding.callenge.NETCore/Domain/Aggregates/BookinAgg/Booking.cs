using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.EventAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.FurnitureAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.StatusAgg;

namespace puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public DateTime BookingDate { get; set; }
        public string RentalDetails { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int FurnitureId { get; set; }
        public List<Furniture?> Furnitures { get; set; }
    }
}
