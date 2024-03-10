using dal.models;
using dto.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.interfaces
{
    public interface IUserBll
    {
        List<dto.classes.User> Getall();
        int add(dto.classes.User user);

        bool delete(int id);
        bool upDate(dto.classes.User user, int id);
        dto.classes.User GetUserByMailAndPassword(string email, string password);
        List<BookingDto> GetAllTrips(int id);
    }
}
