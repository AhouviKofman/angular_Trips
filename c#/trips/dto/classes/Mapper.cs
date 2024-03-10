using AutoMapper;
using dal.interfaces;
using dal.models;
using dto.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dto.mapper
{
    public class mapper : Profile
    {
        public mapper()
        {
            CreateMap<BookingDto, Booking>()
                .ForMember(dest => dest.IdBooking, opt => opt.Ignore());

            //Ignore אם הקוד הוא מספור אוטומטי לא נרצה שבהמרה מהלקוח לשרת יעדכנו את הקוד - לכן נשתמש ב
            CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.fullName, opt =>
            {
                opt.MapFrom(src => src.IdUserNavigation.UserFirstName + src.IdUserNavigation.UserLastName);
            });
            
                  CreateMap<dto.classes.Trip, dal.models.Trip>()
                 .ForMember(dest => dest.IdTrips, opt => opt.Ignore());
                  CreateMap< dal.models.Trip, dto.classes.Trip>()
                 .ForMember(dest => dest.typeName, opt => opt.MapFrom(src => src.IdTypeNavigation.NameType)); 
            //
            CreateMap< dal.models.TripsType, dto.classes.TripsType> ();
            CreateMap<dto.classes.TripsType, dal.models.TripsType>()
            .ForMember(dest => dest.IdType, opt => opt.Ignore());
            //
            //CreateMap<dto.classes.User, dal.models.User>();
            CreateMap<dal.models.User, dto.classes.User>();
            CreateMap<dto.classes.User, dal.models.User>()
            .ForMember(dest => dest.IdUser, opt => opt.Ignore());
            //CreateMap<dto.classes.User, dal.models.User>().ReverseMap();
        }
    }
}
