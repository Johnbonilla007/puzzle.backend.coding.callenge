using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.EventAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.StatusAgg;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Dtos;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos
{
    public class GetBookingDto
    {
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public EventDto Event { get; set; }
        public int ClientId { get; set; }
        public ClientDto Client { get; set; }
        public DateTime BookingDate { get; set; }
        public string RentalDetails { get; set; }
        public string Status { get; internal set; }
    }

    public class EventDto
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal RentalFee { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
