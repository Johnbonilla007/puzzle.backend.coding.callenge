using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Commands.AddUpdateBookingCommand;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Commands.DeleteBookingCommand;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Queries.GetAllBookingListQuery;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;

namespace puzzle.backend.coding.callenge.NETCore.Controllers
{
    [ApiController]
    [Route("api/v2/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IGetAllBookingListQuery _getAllBookingListQuery;
        private readonly ICreateOrUpdateBookingCommand _createBookingCommand;
        private readonly IDeleteBookingCommand _deleteBookingCommand;

        public BookingController(IGetAllBookingListQuery getAllBookingListQuery,
                                 ICreateOrUpdateBookingCommand createBookingCommand,
                                 IDeleteBookingCommand deleteBookingCommand)
        {
            _getAllBookingListQuery = getAllBookingListQuery;
            _createBookingCommand = createBookingCommand;
            _deleteBookingCommand = deleteBookingCommand;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBookingListAsync()
        {
            List<GetBookingDto> bookins = await _getAllBookingListQuery.GetAllBookingListAsync();

            return Ok(bookins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookingById(int id)
        {
            GetBookingDto? booking = await _getAllBookingListQuery.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrUpdateBookingCommand(CreateOrUpdateBookingRequest createOrUpdateBookingRequest)
        {
            Response response = await _createBookingCommand.ExecuteAsync(createOrUpdateBookingRequest);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUpdateBooking(int id)
        {
            Response? response = await _deleteBookingCommand.ExecuteAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
