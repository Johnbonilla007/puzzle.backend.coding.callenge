using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.StatusAgg;

namespace puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
