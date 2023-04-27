using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Commands.DeleteBookingCommand
{
    public interface IDeleteBookingCommand
    {
        Task<Response?> ExecuteAsync(int id);
    }
}
