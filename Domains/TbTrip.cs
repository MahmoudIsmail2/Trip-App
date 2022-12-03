using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains;

public partial class TbTrip
{
   
    public int Tripid { get; set; }
    [Required(ErrorMessage ="Enter Trip Name")]
    [MaxLength(50,ErrorMessage ="Trip Name Must Be Shorter")]
    [MinLength( 5,ErrorMessage ="Trip Name Too Small")]
    public string Tripname { get; set; } = null!;
    [Required(ErrorMessage ="Enter Trip Price")]
    public decimal Tripprice { get; set; }

    public int Imgid { get; set; }
    [Required(ErrorMessage ="plese chose trip category")]
    public int Categoryid { get; set; }
    [MaxLength(100)]
    [Required(ErrorMessage ="You Must Write Description")]
    public string Tripdescreption { get; set; } = null!;
    [Required(ErrorMessage = "plese chose trip city")]
    public int Cityid { get; set; }

    public virtual TbCategory Category { get; set; } = null!;

    public virtual TbCity City { get; set; } = null!;

    public virtual TbImg Img { get; set; } = null!;

    public virtual ICollection<TbTicket> TbTickets { get; } = new List<TbTicket>();
}
