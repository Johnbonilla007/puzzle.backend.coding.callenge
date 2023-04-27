using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;

namespace puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.StatusAgg
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public List<Client> Clients { get; set; }
    }
}
