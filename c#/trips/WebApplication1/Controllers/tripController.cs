using bll.interfaces;
using dal.models;
using dto.classes;
using Microsoft.AspNetCore.Mvc;
using bll.functions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tripController : ControllerBase
    {
        ITripBll bll;

        public tripController(ITripBll bll)
        {
            this.bll = bll;
        }
        [HttpGet, Route("getAllTrip")]
        public List<dto.classes.Trip> getAll()
        {
            return this.bll.getAll();
        }
        [HttpPut, Route("updateTrip")]
        public bool put(dto.classes.Trip trip, int id)
        {
            return this.bll.update(trip, id);
        }

        [HttpGet, Route("getTripByIdTrip/{id}")]
        public dto.classes.Trip getTripById(int id)
        {
            return this.bll.getById(id);
        }
        [HttpPost, Route("addTrip")]
        public int addTrip(dto.classes.Trip trip)
        {
            return this.bll.add(trip);
        }
        [HttpGet, Route("GetInvitesToTrip")]
        public List<BookingDto> GetInvitesToTrip(int id)
        {
            return this.bll.GetInvitesToTrip(id);
        }


        //    }
        //} 
    }
}