using AutoMapper;
using bll.interfaces;
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
    public class FTripBll : ITripBll
    {
        ITripDal dal;
        IMapper mapper;

        public FTripBll(ITripDal dal)
        {
            this.dal = dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<dto.mapper.mapper>();
            });
            mapper = config.CreateMapper();
        }
        //שליפת כל הטיולים

        public List<dto.classes.Trip> getAll()
        {
            return mapper.Map<List<dal.models.Trip>, List<dto.classes.Trip>>(dal.getAll());
        }
        //הוספה
        public int add(dto.classes.Trip Trip)
        {
            var mapTrip = mapper.Map<dal.models.Trip>(Trip);
            return dal.add(mapTrip);
        }
       
        //שליפת טיול על פי קוד
        public dto.classes.Trip getById(int id)
        {
            dal.models.Trip t = dal.TripById(id);
            if (t != null)
            {
                return mapper.Map<dal.models.Trip, dto.classes.Trip>(t);
            }
            return null;
        }
        //החזרת רשימת הזמנות לטיול מסוים
        public List<BookingDto> GetInvitesToTrip(int id)
        {
            return mapper.Map<List<Booking>, List<BookingDto>>(dal.GetInvitesToTrip(id));
        }

        //עדכון טיול

        public bool update(dto.classes.Trip Trip, int id)
        {
            var mapTrip = mapper.Map<dal.models.Trip>(Trip);
            return dal.update(mapTrip,id);
        }
    }
}

