using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.EventAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.FurnitureAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Core;

namespace puzzle.backend.coding.callenge.NETCore.Domain.Services.BookingDomainServices
{
    public class BookingDomainService : IBookingDomainService
    {
        public DomainExceptionError? CanMakeBooking(DateTime bookingDate)
        {
            if (bookingDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return new DomainExceptionError
                {
                    ValidationErrorMessage = "Bookings should not be allowed on Sundays."
                };
            }

            return null;
        }

        public DomainExceptionError? ValidateAgeOfTheClient(Booking booking)
        {
            var ageOfTheClient = (DateTime.Now.Year - booking.Client.DateOfBirth.Year);

            if (ageOfTheClient < 21)
            {
                return new DomainExceptionError { ValidationErrorMessage = "Only clients over 21 years old are allowed to make a booking" };
            }

            return null;
        }

        public DomainExceptionError? ValidateAvailableOfFurniture(List<Furniture> furnitures)
        {
            if (furnitures.Any(x => x.State != FurnitureStatus.Available))
            {
                return new DomainExceptionError
                {
                    ValidationErrorMessage = "Furniture isn't available."
                };
            }

            return null;
        }

        public DomainExceptionError? ValidateBookingExistance(Booking? existingBooking, Booking newBooking)
        {
            if (existingBooking.BookingDate == newBooking.BookingDate)
            {
                return new DomainExceptionError { ValidationErrorMessage = "Booking time conflicts with an existing booking." };
            }

            return null;
        }

        public DomainExceptionError? ValidateBookingHour(DateTime bookingDate)
        {
            if (bookingDate.Date.DayOfWeek >= DayOfWeek.Monday &&
           bookingDate.Date.DayOfWeek <= DayOfWeek.Thursday &&
           bookingDate.Date.TimeOfDay >= TimeSpan.Parse("7:30") &&
           bookingDate.Date.TimeOfDay <= TimeSpan.Parse("21:00"))
            {
                return null;
            };

            return new DomainExceptionError { ValidationErrorMessage = "You're booking out of schedule." };
        }

        public DomainExceptionError? ValidateBookingOutsideAllowedTime(DateTime bookingDate)
        {
            // Check if reservation date is a Friday or Saturday
            if (bookingDate.DayOfWeek == DayOfWeek.Friday || bookingDate.DayOfWeek == DayOfWeek.Saturday)
            {
                // Check if reservation time is between 3pm and 11pm
                TimeSpan bookingTime = bookingDate.TimeOfDay;
                TimeSpan earliestAllowedTime = new TimeSpan(15, 0, 0); // 3pm
                TimeSpan latestAllowedTime = new TimeSpan(23, 0, 0); // 11pm
                if (bookingTime >= earliestAllowedTime && bookingTime <= latestAllowedTime)
                {
                    return null; // Reservation is allowed
                }
                else
                {
                    return new DomainExceptionError { ValidationErrorMessage = "Reservation not allowed because it's outside allowed time range." };
                }
            }
            else
            {
                return null; // Reservation is allowed because it's not a Friday or Saturday
            }
        }

        public DomainExceptionError? ValidateCategory(Event @event)
        {
            if (string.IsNullOrEmpty(@event.Category))
            {
                return new DomainExceptionError { ValidationErrorMessage = "Category is requerid" };
            }

            return null;
        }

        public DomainExceptionError? ValidateClient(Client? client)
        {
            if (client == null)
            {
                return new DomainExceptionError { ValidationErrorMessage = "Client should not null." };
            }

            return null;
        }

        public DomainExceptionError? ValidateFurnitureQuantity(Booking booking)
        {
            decimal? furnitureQuantity = booking.Furnitures?.Count;

            if (furnitureQuantity > 10)
            {
                return new DomainExceptionError { ValidationErrorMessage = "The maximum number of furniture pieces (10) for this reservation has been reached." };
            }

            return null;
        }

        public DomainExceptionError? ValidateStatusClient(Client client)
        {
            if (client.Status == ClientStatus.DUE || client.Status == ClientStatus.CANCELLED)
            {
                return new DomainExceptionError { ValidationErrorMessage = "Status's client invalid." };
            }

            return null;
        }
    }
}
