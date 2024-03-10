using dal.interfaces;
using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.functions
{
    public class FTripsTypeDal : ItripesTypeDal
    {
        TripsContext db;
        public FTripsTypeDal(TripsContext db)
        {

            this.db = db;
        }
        ///-----------------------------------פונקציה המחזירה את כל סוגי הטיולים
        public List<TripsType> getAll()
        {
            return db.TripsTypes.ToList();
        }
        ///---------------------------------------------פונקציה המוסיפה סוג טיול
        public int add(TripsType Trip)
        {
            try
            {
                bool cheak = db.TripsTypes.Any(c => c.NameType == Trip.NameType);
                if (cheak == false)
                {
                    var newType = db.TripsTypes.Add(Trip);
                    db.SaveChanges();

                    if (newType != null)
                    {
                        return Trip.IdType;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return -1;
        }

        ///----------------------------------------------פונקציה המחוחקת סוג טיול

        public bool remove(int id)
        {
            try
            {
                var type = db.TripsTypes.FirstOrDefault(c => c.IdType == id);
                db.TripsTypes.Remove(type);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}
