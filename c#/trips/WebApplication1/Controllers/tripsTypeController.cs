using bll.interfaces;
using bll.Interfaces;
using dal.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tripsTypeController : ControllerBase
    {
        ItripesTypeBll bll;


        public tripsTypeController(ItripesTypeBll bll)
        {
            this.bll = bll;
        }
        [HttpGet, Route("getAllTripTypes")]
        public List<dto.classes.TripsType> GetAll()
        {
            return this.bll.getAll();
        }
        [HttpPost, Route("addTripTypes")]
        public int add(dto.classes.TripsType t)
        {
            return this.bll.add(t);
        }
        
        [HttpDelete, Route("removeTripesType")] 
        public bool delete(int id) {
            return this.bll.remove(id);
        }
        

        }
    }

