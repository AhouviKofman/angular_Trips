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
using dal.models;
namespace bll.functions
{
    public class FuseresBll : IUserBll

    {
        IUser dal;
        IMapper mapper;
        
        public FuseresBll(IUser dal)
        {
            this.dal = dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<dto.mapper.mapper>();
            });
            mapper = config.CreateMapper();
        }
        //שליפת כל המשתמשים
        public List<dto.classes.User> Getall()
        {
            return mapper.Map<List<dal.models.User>, List<dto.classes.User>>(dal.Getall());
        }
        //הוספת משתמש
        public int add(dto.classes.User thisUser)
        {
                try
                {
                    var mapUser = mapper.Map<dal.models.User>(thisUser);
                    return dal.add(mapUser);
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        //שליפת משתמש על פי מייל ופלאפון
            public dto.classes.User GetUserByMailAndPassword(string email, string password)
        {
            dal.models.User u = dal.GetUserByMailAndPassword(email, password);
            if (u != null)
            {
                return mapper.Map<dal.models.User, dto.classes.User>(u);
            }
            return null;
        }
      //מחיקה
        public bool delete(int id)
        {
            return dal.delete(id);
        }
        public bool upDate(dto.classes.User user, int id)
        {
            var mapUser = mapper.Map<dal.models.User>(user);
           return dal.upDate(mapUser, id);
        }
        //כל הטיולים למשתמש מסוים
        public List<BookingDto> GetAllTrips(int id)
        {
            return mapper.Map<List<Booking>, List<BookingDto>>(dal.GetAllTrips(id));
        }
    }
  }
