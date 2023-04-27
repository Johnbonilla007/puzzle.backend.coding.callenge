using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.EventAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.FurnitureAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Core;

namespace puzzle.backend.coding.callenge.NETCore.Domain.Services.BookingDomainServices
{
    public interface IBookingDomainService
    {
        DomainExceptionError? CanMakeBooking(DateTime bookingDate);
        DomainExceptionError? ValidateAgeOfTheClient(Booking booking);
        DomainExceptionError? ValidateAvailableOfFurniture(List<Furniture> furnitures); 
        DomainExceptionError? ValidateBookingExistance(Booking? existingBooking, Booking newBooking);
        DomainExceptionError? ValidateBookingHour(DateTime bookingDate);
        DomainExceptionError? ValidateBookingOutsideAllowedTime(DateTime bookingDate);
        DomainExceptionError? ValidateCategory(Event @event);
        DomainExceptionError? ValidateClient(Client? client);
        DomainExceptionError? ValidateFurnitureQuantity(Booking booking);
        DomainExceptionError? ValidateStatusClient(Client client);
    }
}
