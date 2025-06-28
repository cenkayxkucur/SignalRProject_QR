using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking
            {
                BookingDate = createBookingDto.BookingDate,
                BookingName = createBookingDto.BookingName,
                BookingEmail = createBookingDto.BookingEmail,
                BookingPersonCount = createBookingDto.BookingPersonCount,
                BookingPhone = createBookingDto.BookingPhone

            };
            _bookingService.TAdd(booking);
            return Ok("Booking created successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Booking deleted successfully.");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking
            {
                BookingId = updateBookingDto.BookingId,
                BookingDate = updateBookingDto.BookingDate,
                BookingName = updateBookingDto.BookingName,
                BookingEmail = updateBookingDto.BookingEmail,
                BookingPersonCount = updateBookingDto.BookingPersonCount,
                BookingPhone = updateBookingDto.BookingPhone
            };
            _bookingService.TUpdate(booking);
            return Ok("Booking updated successfully.");

        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);

            return Ok(value);
        }
    }
}
