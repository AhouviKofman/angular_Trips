using AutoMapper;
using bll.Interfaces;
using dal.interfaces;
using dto.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.functions
{
    public class FtripesTypeBll : ItripesTypeBll
    {
        ItripesTypeDal dal;
        IMapper mapper;

        public FtripesTypeBll(ItripesTypeDal dal)
        {
            this.dal = dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<dto.mapper.mapper>();
            });
            mapper = config.CreateMapper();
        }
        //שליפה של כל הסוגים
        public List<TripsType> getAll()
        {

            {
                return mapper.Map<List<dal.models.TripsType>, List<dto.classes.TripsType>>(dal.getAll());

            }
        }
        //הוספה
        public int add(dto.classes.TripsType Trip)
        {
            try
            {
                var mapType = mapper.Map<dal.models.TripsType>(Trip);
                return dal.add(mapType);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //מחיקה
        public bool remove(int id)
        {
            return dal.remove(id);
        }

        public bool upDate(dto.classes.TripsType Trip)
        {
            throw new NotImplementedException();



        }
    }
}
