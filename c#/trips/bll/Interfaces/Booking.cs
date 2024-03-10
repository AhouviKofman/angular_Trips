
using dal.models;
using dto.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.interfaces
{
   public interface IBookingBll
    {
        //List<Booking> getAllToTrip(int id);
        bool add(BookingDto booking);
        List<BookingDto> GetBookings(int idTrip);
        bool remove(int id);
     


    }
    
}
