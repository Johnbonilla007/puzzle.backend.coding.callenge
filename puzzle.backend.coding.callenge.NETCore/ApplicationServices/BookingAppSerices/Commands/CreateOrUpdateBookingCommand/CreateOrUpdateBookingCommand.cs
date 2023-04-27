using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.EventAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.FurnitureAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Core;
using puzzle.backend.coding.callenge.NETCore.Domain.Services.BookingDomainServices;
using puzzle.backend.coding.callenge.NETCore.Infraestructure.DataContext;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Commands.AddUpdateBookingCommand
{
    public class CreateOrUpdateBookingCommand : BaseAppService, ICreateOrUpdateBookingCommand
    {
        private readonly IBookingDomainService _bookingDomainService;
        public CreateOrUpdateBookingCommand(MyDbContext context, IBookingDomainService bookingDomainService) : base(context)
        {
            _bookingDomainService = bookingDomainService;
        }

        public async Task<Response> ExecuteAsync(CreateOrUpdateBookingRequest createOrUpdateRequest)
        {
            if (createOrUpdateRequest == null) return new Response { Success = false };

            Booking? booking = await _context.Bookings.Include(x => x.Client)
                                                      .Include(x => x.Furnitures)
                                                      .Include(x => x.Event)
                                                      .FirstOrDefaultAsync(x => x.BookingId == createOrUpdateRequest.BookingId);

            if (booking == null)
            {
                booking = new Booking
                {
                    BookingDate = createOrUpdateRequest.BookingDate,
                    RentalDetails = createOrUpdateRequest.RentalDetails,
                    ClientId = createOrUpdateRequest.ClientId,
                    EventId = createOrUpdateRequest.EventId,
                    StatusId = createOrUpdateRequest.StatusId,
                };
                booking.Client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == booking.ClientId);
                booking.Furnitures = await _context.Furnitures.Where(x => createOrUpdateRequest.FurnituresId.Contains(x.FurnitureId)).ToListAsync();
                booking.Event = await _context.Events.FirstOrDefaultAsync(x => x.EventId == booking.EventId);

                _context.Entry(booking).State = EntityState.Added;
                await _context.Bookings.AddAsync(booking);

            }
            else
            {
                booking.BookingDate = createOrUpdateRequest.BookingDate;
                booking.RentalDetails = createOrUpdateRequest.RentalDetails;
                booking.ClientId = createOrUpdateRequest.ClientId;
                booking.EventId = createOrUpdateRequest.EventId;
                booking.StatusId = createOrUpdateRequest.StatusId;
                List<int> existingFurnitures = booking.Furnitures.Select(x => x.FurnitureId).ToList();
                List<Furniture> newFurnitures = await _context.Furnitures.Where(f => createOrUpdateRequest.FurnituresId.Contains(f.FurnitureId)
                                                                                 && !existingFurnitures.Contains(f.FurnitureId)).ToListAsync();

                booking.Furnitures.AddRange(newFurnitures);

                _context.Entry(booking).State = EntityState.Modified;
            }

            Booking? existingBooking = await _context.Bookings.Include(x => x.Client).FirstOrDefaultAsync(x => x.BookingDate.Hour == booking.BookingDate.Hour);

            DomainExceptionError? domainExceptionError = ValidateBooking(booking, existingBooking);

            if (domainExceptionError != null)
            {
                return new Response { ValidationErrorMessage = domainExceptionError.ValidationErrorMessage };
            }

            await _context.SaveChangesAsync();

            return new Response { Success = true };
        }

        private DomainExceptionError? ValidateBooking(Booking booking, Booking? existingBooking)
        {
            DomainExceptionError? validation;

            validation = _bookingDomainService.ValidateAgeOfTheClient(booking);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.ValidateBookingExistance(existingBooking, booking);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.CanMakeBooking(booking.BookingDate);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.ValidateAvailableOfFurniture(booking.Furnitures);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.ValidateBookingHour(booking.BookingDate);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.ValidateBookingOutsideAllowedTime(booking.BookingDate);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.ValidateCategory(booking.Event);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.ValidateClient(booking.Client);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.ValidateFurnitureQuantity(booking);

            if (validation != null)
            {
                return validation;
            }

            validation = _bookingDomainService.ValidateStatusClient(booking.Client);

            if (validation != null)
            {
                return validation;
            }

            return null;
        }
    }
}
