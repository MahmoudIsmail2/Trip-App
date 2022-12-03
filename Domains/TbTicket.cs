using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace Domains;

public partial class TbTicket
{
    public TbTicket()
    {
        
    }
    [Key]  
    public int Ticketid { get; set; }
    public int Tripid { get; set; }
    [Required (ErrorMessage ="Enter Your Name")]
    [MaxLength(30,ErrorMessage ="Your Name Must Be Shorter")]
    [MinLength(5,ErrorMessage ="Your Name Is Not Valid")]
    public string Personname { get; set; } = null!;
    [Required(ErrorMessage ="Enter Your Phone Number")]
    [MaxLength(15,ErrorMessage = "Your Phone Must Be Shorter")]
    [MinLength(5,ErrorMessage ="Your Phone Is NoT Valid")]
    public string Personphonenumber { get; set; } = null!;
    [Required(ErrorMessage ="Enter Your Email")]
    [EmailAddress( ErrorMessage ="Your Email is not valid")]
    [MaxLength(40,ErrorMessage = "Your Email Must Be Shorter")]
    [MinLength(10, ErrorMessage = "Your Email is not valid")]
    //[Remote(action: "VerifyEmail", controller: "Home", ErrorMessage = "email found")]

    public string Personemail { get; set; } = null!;

    public virtual TbTrip Trip { get; set; } = null!;
}
