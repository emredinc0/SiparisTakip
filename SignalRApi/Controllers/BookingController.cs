using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

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
        public IActionResult Bookinglist()
        {
            var values=_bookingService.TGetListAll();
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Name = createBookingDto.Name,
                Email = createBookingDto.Email,
                Date = createBookingDto.Date,
                Phone = createBookingDto.Phone,
                PersonCount = createBookingDto.PersonCount,
            };

            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Yapıldı.");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Name = updateBookingDto.Name,
                Email = updateBookingDto.Email,
                Date = updateBookingDto.Date,
                Phone = updateBookingDto.Phone,
                PersonCount = updateBookingDto.PersonCount,

            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi.");
        }
        [HttpGet("Get Booking")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
    }
}
