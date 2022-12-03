using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Trip_System.Areas.Admin.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Trip_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHome : Controller
    {
        IClsTickets tickets;
        IClsTrips trip0;
        IClsCategories clsCategories;
        IClsCities clsCities;
        public AdminHome(IClsTickets _tickets, IClsTrips _trip, IClsCategories _clsCategories, IClsCities _clsCities)
        {
            tickets = _tickets;
            trip0 = _trip;
            clsCategories = _clsCategories;
            clsCities = _clsCities;
        }
        public IActionResult List()
        {
            var r = tickets.GetAll();
            return View(r);
        }
        public IActionResult Categories(string message,string deletemessage)
        {
            var lstcategories  =  clsCategories.GetAll();
            ViewBag.message=message;
            ViewBag.deletemessage = deletemessage;
            return View(lstcategories);
        }
        [HttpPost]
        public IActionResult AddCategory(string categoryname)
        {
            TbCategory category = new TbCategory();   
            category.Categoryname=categoryname;
           var result= clsCategories.Add(category);
            if(result==true)
            {
                string message = "Done";
                return RedirectToAction("Categories", new { message });
            }
           
            return RedirectToAction("Categories" );
        }
        public IActionResult DeleteCategory(int categoryid)
        {

           var result=   clsCategories.Delete(categoryid);
            if (result == true)
            {
                string deletemessage = "deleted";
                return RedirectToAction("Categories", new { deletemessage });
            }

            return RedirectToAction("Categories");
        }
        public IActionResult Trips(string message,string update)
        {
            if(message != null)
            {
                ViewBag.message = message;  
            }
            if (update != null)
            {
                ViewBag.update = update;
            }


            var result = trip0.GetAll();
            return View(result);
        }
        public IActionResult Edit(int id)
        {
          
         
            if (id != 0)
            {
                ClsImgs cls=new ClsImgs();
                VmEditPage vmEditPage0=new VmEditPage();
                vmEditPage0.lstcategories = clsCategories.GetAll();
                vmEditPage0.lstcities = clsCities.GetAll();
                var res= trip0.GetTripById(id);
              

                vmEditPage0.Trip = res;
               
                return View(vmEditPage0);   
                       
            }
            VmEditPage vmEditPage = new VmEditPage();
            vmEditPage.lstcategories = clsCategories.GetAll();
            vmEditPage.lstcities = clsCities.GetAll();
            return View(vmEditPage);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        
        public IActionResult Save(TbTrip trip, int Id, List<IFormFile> files)
        {
            trip.Tripid = Id;
            var imgname = UploadImage(files);
            ClsImgs clsImgs = new ClsImgs();
            TbImg i = new TbImg();
            i.Imgname = imgname;
            clsImgs.Save(i);
            var id = clsImgs.GetId(i);
            trip.Imgid = id;

            ModelState.Remove("trip.Img");
            ModelState.Remove("trip.City");
            ModelState.Remove("trip.Category");
           
            if (ModelState.IsValid)
            {           
                var result = trip0.Save(trip);
                string message;
                string update;
                if (Id==0)
                {
                    message = "addeddone";
                    return RedirectToAction("Trips", new { message });
                }
                else
                {
                    update = "Done";
                    return RedirectToAction("Trips" ,new { update });
                }
                                         
                
            }
            else
            {
                VmEditPage vmEditPage = new VmEditPage();
                vmEditPage.lstcategories = clsCategories.GetAll();
                vmEditPage.lstcities = clsCities.GetAll();
                vmEditPage.Trip = trip;
                return View("Edit", vmEditPage);
            }
         


        }
        public IActionResult Delete(int id)
        {
            var t=  trip0.GetTripById(id);
            trip0.Delete(t);
            return RedirectToAction("Trips");
        }
       
        string UploadImage(List<IFormFile> Files)
        {
          
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Trip Home Page", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                       
                        file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }
            
        }


    
}
