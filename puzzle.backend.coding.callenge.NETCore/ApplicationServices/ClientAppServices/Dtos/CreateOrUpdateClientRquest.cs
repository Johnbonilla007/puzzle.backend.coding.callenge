using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.StatusAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Core;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Dtos
{
    public class CreateOrUpdateClientRquest
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
