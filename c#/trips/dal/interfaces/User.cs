using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.interfaces
{
    public interface IUser
    {
       List<User> Getall();
       int add(User user);
        
       bool delete(int id);
       bool upDate(User user, int id);
       User GetUserByMailAndPassword(string email, string password);
       List<Booking> GetAllTrips(int id);

    }
}
