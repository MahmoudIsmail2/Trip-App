using Domains;

namespace Trip_System.Models
{
    public class ApiResponce
    {
        public object Data { get; set; }

        public string Errors { get; set; } = "";

        public int StatusCode { get; set; }
    }
}
