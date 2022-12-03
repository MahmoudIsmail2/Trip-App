using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;


namespace Bl
{
    public interface IClsTrips
    {
        public List<VwTrip> GetAll();
        public VwTrip GetById(int id);
        public bool Save(TbTrip trip);
        public bool Delete(TbTrip trip);
        public TbTrip GetTripById(int id);
        
    }
    public class ClsTrips : IClsTrips
    {
        TripsSystemContext context;
        public ClsTrips(TripsSystemContext _context)
        {
            context = _context;
        }
        public List<VwTrip> GetAll()
        {
            try
            {
                var lsttrips = context.VwTrips.ToList();
                return lsttrips;
            }
            catch (Exception ex)
            {
                return new List<VwTrip>();
            }
        }
        public VwTrip GetById(int id)
        {
            try
            {              
                var trip=context.VwTrips.FirstOrDefault(a=> a.Tripid==id);
                return trip;
            }
            catch(Exception ex)
            {
                return new VwTrip();
            }
        }
        public TbTrip GetTripById(int id)
        {
            try
            {
                var trip = context.TbTrips.FirstOrDefault(a => a.Tripid == id);
                return trip;
            }
            catch (Exception ex)
            {
                return new TbTrip();
            }
        }
        public bool Save(TbTrip trip)
        {
            try
            {
                if(trip.Tripid==0)
                {
                    var result = context.TbTrips.Add(trip);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    context.Entry(trip).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
               
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(TbTrip trip)
        {
            try
            {
                context.TbTrips.Remove(trip);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
