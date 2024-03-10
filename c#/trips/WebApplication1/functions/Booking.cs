using dal.interfaces;
using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dal.functions.BookingDal;

namespace dal.functions
{
    public class BookingDal 
        //: IBookingDAl
    {
        TripsContext db;

        public BookingDal(TripsContext db)
        {
            this.db = db;
        }
        public List<Booking> 
            getAll()
        {
            List<Booking> list = db.Bookings.ToList();
            //foreach (var booking in list)
            //{
            //    booking.IdBooking = db.Bookings.FirstOrDefault(c => c.IdBooking == booking.IdBooking);

            //    //recipe.Level = db.Levels.FirstOrDefault(l => l.Id == recipe.LevelId);
            //    //recipe.User = db.Users.FirstOrDefault(u => u.Id == recipe.UserId);
            //    //recipe.IngredientsToRecipes = db.IngredientsToRecipes.Where(i => i.RecipeId == recipe.Id).ToList();
            //}
            return list;
        }

    }
}
