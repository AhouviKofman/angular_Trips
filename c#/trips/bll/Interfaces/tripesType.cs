using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.Interfaces
{
    public interface ItripesTypeBll
    {
        List<dto.classes.TripsType> getAll();
        int add(dto.classes.TripsType Trip);
        bool remove(int id);
        bool upDate(dto.classes.TripsType Trip);
    }
}
