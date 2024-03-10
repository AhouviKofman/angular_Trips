using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.interfaces
{
    public interface ITripDal
    {
        List<Trip> getAll();
        int add(Trip Trip);
       
        bool update(Trip Trip, int id);
        Trip TripById(int id);
        List<Booking> GetInvitesToTrip(int id);
    }
}
