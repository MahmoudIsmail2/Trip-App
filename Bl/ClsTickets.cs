using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IClsTickets
    {
        public bool Save(TbTicket ticket);
        public List<VwTicket> GetAll();
    }
    public class ClsTickets:IClsTickets
    {
        TripsSystemContext context;
        public ClsTickets(TripsSystemContext _context )
        {
            context = _context;

        }
        public bool Save(TbTicket ticket)
        {
            try
            {
                context.TbTickets.Add(ticket);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public List<VwTicket> GetAll()
        {
            try
            {
                var results=  context.VwTickets.ToList();
                return results;
            }
            catch(Exception ex)
            {
                return new List<VwTicket>();
            }
        }
    }
}
