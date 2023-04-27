using Microsoft.EntityFrameworkCore;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Infraestructure.DataContext;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Queries.GetAllBookingListQuery
{
    public class GetAllBookingListQuery : BaseAppService, IGetAllBookingListQuery
    {
        public GetAllBookingListQuery(MyDbContext context) : base(context)
        {
        }

        public async Task<List<GetBookingDto>> GetAllBookingListAsync()
        {
            List<GetBookingDto> bookingDtos = new List<GetBookingDto>();
            List<Booking> bookings = await _context.Bookings.Include(x => x.Client)
                                                           .Include(x => x.Event)
                                                           .Include(x => x.Status).ToListAsync();

            if (bookings != null && bookings.Any())
            {
                bookingDtos = bookings.Select(x => new GetBookingDto
                {
                    BookingId = x.BookingId,
                    BookingDate = x.BookingDate,
                    RentalDetails = x.RentalDetails,
                    Status = x.Status.Name,
                    Event = new EventDto
                    {
                        EventId = x.EventId,
                        Name = x.Event.Name,
                        Category = x.Event.Category,
                        RentalFee = x.Event.RentalFee,
                        Description = x.Event.Description,
                        Location = x.Event.Location,
                        StartTime = x.Event.StartTime,
                        EndTime = x.Event.EndTime,
                    },
                    Client = new ClientDto
                    {
                        ClientId = x.Client.ClientId,
                        FirstName = x.Client.FirstName,
                        LastName = x.Client.LastName,
                        Email = x.Client.Email,
                        Phone = x.Client.Phone,
                        DateOfBirth = x.Client.DateOfBirth,
                    }
                }).ToList();
            }

            return bookingDtos;
        }

        public async Task<GetBookingDto?> GetBookingByIdAsync(int id)
        {
            if (id == 0) return null;

            Booking? booking = await _context.Bookings.Include(r => r.Client)
                                                    .Include(x => x.Event)
                                                    .Include(x => x.Status).FirstOrDefaultAsync(r => r.BookingId == id);

            if (booking == null) return null;

            return new GetBookingDto
            {
                BookingId = booking.BookingId,
                BookingDate = booking.BookingDate,
                RentalDetails = booking.RentalDetails,
                Status = booking.Status.Name,
                Event = new EventDto
                {
                    EventId = booking.EventId,
                    Name = booking.Event.Name,
                    Category = booking.Event.Category,
                    RentalFee = booking.Event.RentalFee,
                    Description = booking.Event.Description,
                    Location = booking.Event.Location,
                    StartTime = booking.Event.StartTime,
                    EndTime = booking.Event.EndTime,
                },
                Client = new ClientDto
                {
                    ClientId = booking.Client.ClientId,
                    FirstName = booking.Client.FirstName,
                    LastName = booking.Client.LastName,
                    Email = booking.Client.Email,
                    Phone = booking.Client.Phone,
                    DateOfBirth = booking.Client.DateOfBirth,
                }
            };

        }
    }
}
