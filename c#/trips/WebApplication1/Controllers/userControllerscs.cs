using bll.interfaces;
using dal.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userControllerscs :ControllerBase
        {
        IUserBll bll;

        public userControllerscs(IUserBll bll)
        {
            this.bll = bll;
        }
        [HttpGet,Route("getAllUsers")]
        public List<dto.classes.User> GetAll()
        {
            return this.bll.Getall();
        }
        [HttpPost ,Route("addUser")]
        public int add(dto.classes.User user)
        {
            return this.bll.add(user);
        }
        //getMakor2/{seffer}/{word}
        [HttpGet, Route("getByEmailAndPhone/{email}/{phone}")]
        public dto.classes.User getByEmailAndPhone(string email,string phone) { 
        return this.bll.GetUserByMailAndPassword(email,phone);
        }
        [HttpDelete,Route("removeUserById/{id}")]
        public bool delete(int id) { 
        return this.bll.delete(id);
        }
        [HttpPut, Route("apdateUser/{id}")]
        public bool put(dto.classes.User user, int id)
        {
            return this.bll.upDate(user, id);
        }
        [HttpGet, Route("GetAllTripsForUser/{id}")]
        public List<dto.classes.BookingDto> GetAllTrips(int id)
        {
            return this.bll.GetAllTrips(id);
        }

    }
    }

