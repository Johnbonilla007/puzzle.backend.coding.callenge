using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.FurnitureAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Core;
using puzzle.backend.coding.callenge.NETCore.Domain.Services.BookingDomainServices;

namespace puzzle.backend.coding.callenge.NETCore.Tests.UnitTesting.Domain.Services
{
    [Trait("Booking", "")]
    public class BookingDomainServiceTest
    {
        private IBookingDomainService _bookingDomainService;

        public BookingDomainServiceTest()
        {
            _bookingDomainService = new BookingDomainService();
        }

        [Fact]
        public void MakeBooking_ClientIsUnder21_ThrowsException()
        {
            // Arrange
            var client = new Client
            {
                ClientId = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(2005, 02, 05)
            };
            var booking = new Booking
            {
                Client = client,
                ClientId = client.ClientId,
                BookingDate = DateTime.Now,
                RentalDetails = "Unit Test",
                EventId = 1,

            };
            DomainExceptionError expect =
                new DomainExceptionError { ValidationErrorMessage = "Only clients over 21 years old are allowed to make a Booking" };


            //Act
            DomainExceptionError? result = _bookingDomainService.ValidateAgeOfTheClient(booking);

            // Assert
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }

        [Fact]
        public void MakeBooking_ClientIsOver21_ReturnsBooking()
        {
            // Arrange
            var client = new Client
            {
                ClientId = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(2000, 02, 05)
            };
            var booking = new Booking
            {
                Client = client,
                ClientId = client.ClientId,
                BookingDate = DateTime.Now,
                RentalDetails = "Unit Test",
                EventId = 1,

            };
            DomainExceptionError? expect = null;

            //Act
            DomainExceptionError? result = _bookingDomainService.ValidateAgeOfTheClient(booking);

            // Assert
            Assert.Equal(expect, result);
        }

        [Fact]
        public void CreateBooking_ShouldNotAllowConflictWithExistingBooking()
        {
            // Arrange
            var existingBooking = new Booking
            {
                BookingId = 1,
                BookingDate = DateTime.Parse("2023-05-01 10:00:00"),
                RentalDetails = "Conference",
                ClientId = 1,
            };

            // Act
            var newBooking = new Booking
            {
                BookingDate = existingBooking.BookingDate,
                RentalDetails = "Wedding",
                ClientId = 2,
            };
            DomainExceptionError expect = new DomainExceptionError { ValidationErrorMessage = "Booking time conflicts with an existing Booking." };

            DomainExceptionError result = _bookingDomainService.ValidateBookingExistance(existingBooking, newBooking);


            // Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result.ValidationErrorMessage);
        }

        [Fact]
        public void CreateBooking_InvalidTime_ReturnsFalse()
        {
            // Arrange
            var Booking = new Booking
            {
                BookingDate = new DateTime(2023, 4, 28, 6, 30, 0) // Thursday before 7:30am
            };

            DomainExceptionError expect = new DomainExceptionError { ValidationErrorMessage = "You're booking out of schedule." };

            // Act
            DomainExceptionError? result = _bookingDomainService.ValidateBookingHour(Booking.BookingDate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }

        [Fact]
        public void CannotReserveOutsideAllowedTimes()
        {
            // Arrange
            var booking = new Booking
            {
                BookingDate = new DateTime(2023, 04, 29, 14, 30, 00), // Sunday at 2:30pm
                // other reservation properties
            };
            DomainExceptionError expect = new DomainExceptionError { ValidationErrorMessage = "Reservation not allowed because it's outside allowed time range." };

            // Act
            DomainExceptionError? result = _bookingDomainService.ValidateBookingOutsideAllowedTime(booking.BookingDate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }

        [Fact]
        public void CannotMakeReservationOnSunday()
        {
            // Arrange

            var booking = new Booking
            {
                BookingDate = new DateTime(2022, 05, 01, 14, 30, 0), // Sunday, May 1st, 2022
            };

            DomainExceptionError expect = new DomainExceptionError { ValidationErrorMessage = "Bookings should not be allowed on Sundays." };

            // Act
            DomainExceptionError? result = _bookingDomainService.CanMakeBooking(booking.BookingDate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }

        [Fact]
        public void CreateReservation_WithoutClient_ShouldThrowException()
        {
            // Arrange
            var booking = new Booking();
            DomainExceptionError expect = new DomainExceptionError { ValidationErrorMessage = "Client should not null." };

            // Act
            DomainExceptionError? result = _bookingDomainService.ValidateClient(booking.Client);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }

        [Fact]
        public void ReserveFurniture_FurnitureNotAvailable_ReturnsFalse()
        {
            // Arrange
            var furniture = new List<Furniture>{
                new Furniture
                {
                    FurnitureId = 1,
                    Name = "Table",
                    State = FurnitureStatus.Reserved
                }};

            var booking = new Booking
            {
                BookingDate = new DateTime(2023, 5, 1, 10, 0, 0),
                Furnitures = furniture,
            };
            DomainExceptionError expect = new DomainExceptionError { ValidationErrorMessage = "Furniture isn't available." };


            // Act
            DomainExceptionError? result = _bookingDomainService.ValidateAvailableOfFurniture(booking.Furnitures);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }

        [Fact]
        public void Reservation_Must_Have_Category()
        {
            // Arrange
            var booking = new Booking
            {
                ClientId = 1,
                BookingDate = DateTime.Now.AddDays(7),
                Event = new NETCore.Domain.Aggregates.EventAgg.Event
                {
                    Category = string.Empty
                }
            };
            DomainExceptionError expect = new DomainExceptionError { ValidationErrorMessage = "Category is requerid" };

            // Act
            DomainExceptionError? result = _bookingDomainService.ValidateCategory(booking.Event);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }

        [Fact]
        public void Test_MaximumFurniturePerReservation()
        {
            // Arrange
            var booking = new Booking
            {

                ClientId = 1,
                EventId = 2,
                BookingDate = new DateTime(2022, 5, 1, 14, 0, 0),
                Furnitures = new List<Furniture>()
            };

            for (int i = 0; i < 11; i++)
            {
                booking.Furnitures.Add(new Furniture
                {
                    FurnitureId = i + 1,
                    State = FurnitureStatus.Available
                });
            }
            DomainExceptionError expect = new DomainExceptionError
            {
                ValidationErrorMessage = "The maximum number of furniture pieces (10) for this reservation has been reached."
            };


            // Act
            DomainExceptionError? result = _bookingDomainService.ValidateFurnitureQuantity(booking);


            // Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }

        [Fact]
        public void Cannot_Create_Reservation_For_Due_Or_Cancelled_Client()
        {
            // Arrange
            var booking = new Booking
            {
                BookingDate = DateTime.Now.AddDays(7),
                EventId = 1,
                Furnitures = new List<Furniture>(),
                ClientId = 1,
            };

            var client = new Client
            {
                FirstName = "John Doe",
                DateOfBirth = new DateTime(2000, 05, 15),
                Status = ClientStatus.DUE
            };

            booking.Client = client;

            DomainExceptionError expect = new DomainExceptionError
            {
                ValidationErrorMessage = "Status's client invalid."
            };

            // Act
            DomainExceptionError? result = _bookingDomainService.ValidateStatusClient(booking.Client);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expect.ValidationErrorMessage, result?.ValidationErrorMessage);
        }
    }
}
