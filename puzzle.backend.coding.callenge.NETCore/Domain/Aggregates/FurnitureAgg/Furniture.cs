using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;

namespace puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.FurnitureAgg
{
    public class Furniture
    {
        public int FurnitureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal RentalFee { get; set; }
        public Booking Booking { get; set; }
    }
}
