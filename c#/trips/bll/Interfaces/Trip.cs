using dal.models;
using dto.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.interfaces
{
    public interface ITripBll
    {
        List<dto.classes.Trip> getAll();
        int add(dto.classes.Trip Trip);
        bool update(dto.classes.Trip Trip, int id);
        dto.classes.Trip getById(int id);
        List<BookingDto> GetInvitesToTrip(int id);
    }
}
