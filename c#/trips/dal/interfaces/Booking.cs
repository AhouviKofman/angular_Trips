
using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.interfaces
{
   public interface IBooking
    {
        List<Booking> getAllToTrip(int id);
        bool add(Booking booking);
        bool remove(int id);
        //List<Booking> Add(Booking booking);
       

    }
    
}
