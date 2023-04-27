using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Commands.AddUpdateBookingCommand
{
    public interface ICreateOrUpdateBookingCommand
    {
        Task<Response> ExecuteAsync(CreateOrUpdateBookingRequest postBookingRequest);
    }
}
