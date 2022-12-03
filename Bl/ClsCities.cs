using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IClsCities
    {
        public List<TbCity> GetAll();
    }
    public class ClsCities : IClsCities
    {
        TripsSystemContext context;
        public ClsCities(TripsSystemContext _context)
        {
            context = _context;
        }
        public List<TbCity> GetAll()
        {
            try
            {
                var lstcities = context.TbCities.ToList();
                return lstcities;
            }
            catch (Exception ex)
            {
                return new List<TbCity>();
            }
        }
    }
}


