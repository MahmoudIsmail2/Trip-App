using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using Trip_System.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trip_System.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IClsTrips trips;
        public ValuesController(IClsTrips _trips)
        {

            trips = _trips;
        }
        // GET: api/<ValuesController>
        
        [HttpGet]
        public ApiResponce Get()
        {
            ApiResponce responce = new ApiResponce();
            responce.Data = trips.GetAll();
            responce.Errors = null;
            responce.StatusCode = 200;
            return responce;

        }

        // GET api/<ValuesController>/5
        
        [HttpGet("{GetById}/{id}")]
        //[Route("GetById")]
        public ApiResponce GetById(int id)
        {
            ApiResponce responce = new ApiResponce();
            responce.Data = trips.GetTripById(id);
            if (responce.Data != null)
            {
                responce.StatusCode = 200;
                responce.Errors = null;
            }



            return responce;
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("Create")]

        public IActionResult Create([FromBody] ApiResponce responce)
        {
            TbTrip t = new TbTrip();
            var data = (responce.Data);

           

           
            trips.Save(t);
          
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ApiResponce responce)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{Delete}/{id}")]
        public string Delete(int id)
        {

            var result = trips.GetTripById(id);
            trips.Delete(result);
            return "Deleted";
        }
    }
}
