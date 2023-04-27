


namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos
{
    public class CreateOrUpdateBookingRequest
    {
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public int ClientId { get; set; }
        public DateTime BookingDate { get; set; }
        public string RentalDetails { get; set; }
        public int StatusId { get; set; }
        public List<int> FurnituresId { get; set; }

        public List<FurnitureDto> Furnitures { get; set; }
    }

    public class FurnitureDto
    {
        public int FurnitureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public decimal RentalFee { get; set; }
    }
}
