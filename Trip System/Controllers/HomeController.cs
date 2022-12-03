using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trip_System.Models;

namespace Trip_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IClsTrips trips;
        IClsTickets t;
        public HomeController(ILogger<HomeController> logger, IClsTrips _trips, IClsTickets _t)
        {
            trips = _trips;
            _logger = logger;
            t = _t;
        }

        public IActionResult Index(string? message)
        {
            if (message != null)
            {
                ViewBag.Message = message;

            }      
            var tr = trips.GetAll();
            return View(tr);

        }
        public IActionResult TestApi()
        {
           
            return View();

        }
        public IActionResult TripDetails(int id)
        {
            var result = trips.GetById(id);
            return View(result);
        }
        public IActionResult Ticket(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {
            if (false)
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
        }
        public IActionResult Book(TbTicket ticket, int id)
        {
            ModelState.Remove("Trip");
            ticket.Tripid = id;
            if (ModelState.IsValid)
            {
               var r= t.Save(ticket);
                if(r==true)
                {
                    string message = "Done";
                    return RedirectToAction("Index", new { message });
                }
                else
                {
                    return View("Ticket", ticket);
                }

            }
            else
            {
                return View("Ticket", ticket);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}