using dal;
using dal.interfaces;
using dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.functions
{
    public class FBookingDal : IBooking
    {
         TripsContext db;
        public FBookingDal(TripsContext db) {

            this.db = db;
        }
        ///-----------------------------------פונקציה מעטפת הבודקת את תקינות תאריך ההזמנה
        //האם התאריך רלוונטי
        public static bool checkDate(DateTime? date)
        {
            if (date < DateTime.Now)
                return false;
            return true;
        }


        ///---------------------פונקציה המוסיפה הזמנה במידה שהתאריך תקין ושיש מקום בטיול
        bool IBooking.add(Booking order)
        {
            {
                try
                {
                    var t = db.Trips.ToList().Find(x => x.IdTrips == order.IdTrip);
                    if (t != null && t.PlacesAvailable >= order.Places)
                    {
                        order.DateBookink = DateTime.Today;
                        //order.TimeBooking = new TimeSpan(DateTime.Now.Hour);
                        db.Add(order);
                        t.PlacesAvailable -= order.Places;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }


        ///-----------------------------------פונקציה המחזירה את כל ההזמנות לטיול מסוים
        public List<Booking> getAllToTrip(int id)
        {
            //var newBooking = db.Bookings.Include(p => p.IdUserNavigation);
            List<Booking> result = new List<Booking>();
            

            foreach (var i in db.Bookings)
            {
                if (i.IdBooking == id)
                    result.Add(i);
            }
            if (result.Count > 0)
                return result;
            return null;
        }
        ///----------------פונקציה המוחקת הזמנה במידה והטיול לא היה וכן מעדכנת את המקומות בטיול
        
        public bool remove(int id)
        {
            try
            {
                Booking b = db.Bookings.FirstOrDefault(x => x.IdBooking == id);
                if (b != null)
                {
                    Trip t = db.Trips.FirstOrDefault(x => x.IdTrips == b.IdTrip);
                    if (t.DateTrip > DateTime.Now)
                    {
                        db.Bookings.Remove(b);
                        t.PlacesAvailable = (short)(t.PlacesAvailable - b.Places);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
