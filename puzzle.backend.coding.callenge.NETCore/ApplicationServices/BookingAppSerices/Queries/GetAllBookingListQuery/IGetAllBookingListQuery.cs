using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Queries.GetAllBookingListQuery
{
    public interface IGetAllBookingListQuery
    {
        Task<List<GetBookingDto>> GetAllBookingListAsync();
        Task<GetBookingDto?> GetBookingByIdAsync(int id);
    }
}
