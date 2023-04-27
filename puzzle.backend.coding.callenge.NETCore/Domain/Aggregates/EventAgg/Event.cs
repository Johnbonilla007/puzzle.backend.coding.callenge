using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;

namespace puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.EventAgg
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal RentalFee { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
