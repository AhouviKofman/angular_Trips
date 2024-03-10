using AutoMapper;
using bll.interfaces;
using dal;
using dal.functions;
using dal.interfaces;
using dal.models;
using dto.classes;
using dto.mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.functions
{
    public class FBooking : IBookingBll
    {
        IBooking dal;
        IMapper thisMapper;
        ITripDal t;
        public FBooking(IBooking dal, ITripDal t)
        {
            this.dal = dal;
            this.t = t;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<mapper>();
            });

            thisMapper = config.CreateMapper();
        }




        //שליפת כל ההזמנות לטיול מסוים
        public List<BookingDto> GetBookings(int idTrip)
        {
            return thisMapper.Map<List<Booking>, List<BookingDto>>(dal.getAllToTrip(idTrip));
        }

        // הוספה



        //public bool add(BookingDto booking)
        //{
        //   dal.add(thisMapper.Map<BookingDto, Booking>(booking));
        //   booking.DateBookink = DateTime.Now;
        //    booking.TimeBooking = (short)DateTime.Now.Hour;
        //        return true;

        //    return false;
        //}
        //מחיקה
        public bool remove(int id)
        {
            return dal.remove(id);
        }

        bool IBookingBll.add(BookingDto booking)
        {

            List<dto.classes.Trip> tripList = thisMapper.Map<List<dal.models.Trip>, List<dto.classes.Trip>>(this.t.getAll());
            dto.classes.Trip t = tripList.Find(x => x.IdTrips == booking.IdTrip);
            if (t != null)
            {
                if (t.DateTrip > DateTime.Now)
                    return dal.add(thisMapper.Map<BookingDto, dal.models.Booking>(booking));
            }
            return false;




        }
    }
}

