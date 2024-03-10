using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.interfaces
{
    public interface ItripesTypeDal
    {
        List<TripsType> getAll();
        int add(TripsType Trip);
        bool remove(int id);
        
    }
}
