using dal.interfaces;
using dal.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.functions
{
    public class FuseresDal : IUser

    {
        TripsContext db;
        public FuseresDal(TripsContext db)
        {

            this.db = db;
        }
        ///-----------------------------------פונקציה המחזירה את כל המשמשים
        public List<User> Getall()
        {
            return db.Users.ToList();
        }
        ///---------------------------------------------פונקציה המוסיפה משתמש

        public int add(User user)
        {
            try
            {
                var newUser = db.Users.Add(user);
                db.SaveChanges();
                if (newUser != null)
                {
                    return user.IdUser;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return -1;
        }
        ///----------------------------------------------פונקציה המחזירה משתמש על פי הקוד שלו
        public User getByid(int id)
        {
            User u = (User)db.Users.SingleOrDefault(c => c.IdUser == id);

            return u;
        }
        //מחיקה
        public bool delete(int id)
        {
            try
            {
                var user = getByid(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///----------------------------------------------פונקציה המחזירה משתמש על פי המייל והפלאפון
        public User GetUserByMailAndPassword(string email, string password)
        {
            User u = db.Users.FirstOrDefault(c => c.UserMail == email && c.UserPhone == password);
            //(u => u.UserMail.Equals(email) && u.UserPassword.Equals(password));
            return u;
        }
        ///----------------------------------------------פונקציה המעדכנת משתמש
        public bool upDate(User user, int id)
        {

            User u = (User)db.Users.FirstOrDefault(c => c.IdUser == id);
            if (u != null)
            {
                if (user.UserPhone != "string") {u.UserPhone = user.UserPhone;}
                if (user.UserLastName != "string") { u.UserLastName = user.UserLastName; }
                if (user.UserFirstName != "string") {  u.UserFirstName = user.UserFirstName;}
                if(user.UserMail != "string") { u.UserMail = user.UserMail; }
                if(user.UserPassword != "string") { u.UserPassword = user.UserPassword; };
                if (user.UserFirstAid != u.UserFirstAid) {  u.UserFirstAid = user.UserFirstAid; }
                db.SaveChanges();
                return true;
            }
            return false;

        } ///----------------------------------------------פונקציה המחזירה רשימה של הזמנות למשתמש מסוים
        public List<Booking> GetAllTrips(int id)
        {
           List<Booking> list = new List<Booking>();
            foreach (var  i in db.Bookings)
            {
                if (i.IdUser == id)
                 list.Add(i);       
            }
            if (list.Count > 0)
            return list;
            return null;
        }
    }
}         
           
        
               


            
        
    

