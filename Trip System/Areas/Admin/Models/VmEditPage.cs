using Domains;

namespace Trip_System.Areas.Admin.Models
{
    public class VmEditPage
    {
        public List<TbCategory> lstcategories { get; set; }
        public List<TbCity> lstcities { get; set; }
        public TbTrip Trip { get; set; }
        public TbImg img { get; set; }
    }
}
