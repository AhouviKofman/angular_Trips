using bll.interfaces;
using dto.classes;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookingController : ControllerBase
    {
        IBookingBll bll;

        public bookingController(IBookingBll bll)
        {
            this.bll = bll;
        }
        [HttpGet, Route("getbookingById")]
        public List<BookingDto> getBooking(int id)
        {
            return this.bll.GetBookings(id);
        }

        [HttpPost, Route("addBooking")]
        public bool addBooking(BookingDto bookingDto)
        {
            return this.bll.add(bookingDto);
        }

        [HttpDelete, Route("removeBookingById/{id}")]
        public bool deleteBooking(int id)
        {
            return this.bll.remove(id);
        }



    }
}
