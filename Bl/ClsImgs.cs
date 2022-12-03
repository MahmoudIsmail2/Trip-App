using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
   public class ClsImgs
   {
        public bool Save(TbImg img)
        {
            try
            {
              TripsSystemContext context=new TripsSystemContext();    
                context.TbImgs.Add(img);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public int GetId(TbImg img)
        {
            TripsSystemContext ctx=new TripsSystemContext(); 
            try
            {
                var result=ctx.TbImgs.FirstOrDefault(a=> a.Imgname==img.Imgname);
                return result.Imgid;
            }
            catch
            {
                return 0;
            }
        }
        public string GetById(int id)
        {
            TripsSystemContext ctx = new TripsSystemContext();
            try
            {
                var result = ctx.TbImgs.FirstOrDefault(a => a.Imgid ==id).ToString();
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
