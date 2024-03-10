using AutoMapper;
using dal;
using dal.interfaces;
using dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.functions
{
    public class FTripDal: ITripDal


    {
        TripsContext db;
        public FTripDal(TripsContext db)
        {

            this.db = db;
        }
        ///-----------------------------------פונקציה המחזירה את כל הטיולים
        List<Trip> ITripDal.getAll()
        {
            return db.Trips.Include(p=>p.IdTypeNavigation).ToList();
        }

        /// ---------------------------------פונקציה המחזירה טיול בודד על פי הקוד שלו
        public Trip TripById(int id)
        {
            try
            {
                var newTrip = db.Trips.Include(p => p.IdTypeNavigation).First(x => x.IdTrips == id);
                if (newTrip == null)
                    return null;
                else
                    return newTrip;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        ///-----------------------------------פונקציה המוסיפה טיול שעדיין לא התקיים ...שהמחיר...ש
        public int add(Trip Trip)
        {
            //Trip.DateTrip > DateTime.Now && Trip.DurationTrip > 3
            if (
                Trip.DurationTrip < 13 && Trip.PlacesAvailable > 0 && Trip.Price > 0 && Trip.Price < 2000)
            {
                var newTrip = db.Trips.Add(Trip);
                db.SaveChanges();
                if (newTrip != null)
                {
                    return Trip.IdTrips;
                }
            }
            return -1;

            {
                return -1;
            }
            return -1;
        }
        ///----------------------------פונקציה המחזירה רשימת הזמנות לטיול מסוים
        public List<Booking> GetInvitesToTrip(int id)
        {
            List<Booking> list = new List<Booking>();
            foreach (var i in db.Bookings)
            {
                if (i.IdTrip == id)
                    list.Add(i);
            }
            if (list.Count > 0)
                return list;
            return null;
        }
        ///-----------------------------------פונקציה המעדכנת טיול
        bool ITripDal.update(Trip Trip, int id)
        {
            
            var item = db.Trips.SingleOrDefault(item => item.IdTrips == id);
            if (item != null)
            {       if (Trip.IdType != 0) { item.IdType=Trip.IdType; }
                    if (Trip.LeavingTime != 0) { item.LeavingTime= Trip.LeavingTime; }
                    if (Trip.Image != "string"){ item.Image = item.Image; }
                    //if(item.DateTrip)
                    if(Trip.DurationTrip != 0) {item.DurationTrip= Trip.DurationTrip; }
                    if (Trip.PlacesAvailable != 0) { item.PlacesAvailable = Trip.PlacesAvailable; }
                    if (Trip.DestinationTrip != "string") { item.DestinationTrip = Trip.DestinationTrip; }
                    if (Trip.Price != 0) { item.Price = item.Price; }
                    db.SaveChanges();
                    return true;
              
            }
            return false;
        }
       
    }
    }

