using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IClsCategories
    {
        public List<TbCategory> GetAll();
        public bool Add(TbCategory category);
        public TbCategory GetById(int id);
        public bool Delete(int id);
    }
    public class ClsCategories: IClsCategories
    {
        TripsSystemContext context;
        public ClsCategories(TripsSystemContext _context)
        {
            context = _context;   
        }
        public List<TbCategory> GetAll()
        {
            try
            {
                var lsTcategories = context.TbCategories.ToList();
                return lsTcategories;
            }
            catch (Exception ex)
            {
                return new List<TbCategory>();
            }
        }
        public bool Add(TbCategory category)
        {
            try
            {
                context.TbCategories.Add(category);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TbCategory GetById(int id)
        {
            try
            {
             var category   = context.TbCategories.FirstOrDefault(a => a.Categoryid == id);
                return category;
            }
            catch
            {
                return new TbCategory();
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var cat = GetById(id);
                context.TbCategories.Remove(cat);   
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
