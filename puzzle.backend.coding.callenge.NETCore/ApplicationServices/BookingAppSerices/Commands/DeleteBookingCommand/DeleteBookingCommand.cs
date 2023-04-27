using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Infraestructure.DataContext;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Commands.DeleteBookingCommand
{
    public class DeleteBookingCommand : BaseAppService, IDeleteBookingCommand
    {
        public DeleteBookingCommand(MyDbContext context) : base(context)
        {
        }

        public async Task<Response?> ExecuteAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return null;
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return new Response { Success = true };
        }
    }
}
