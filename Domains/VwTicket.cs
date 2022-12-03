using System;
using System.Collections.Generic;

namespace Domains;

public partial class VwTicket
{
    public string Personname { get; set; } = null!;

    public string Personphonenumber { get; set; } = null!;

    public string Personemail { get; set; } = null!;

    public string Tripname { get; set; } = null!;

    public decimal Tripprice { get; set; }

    public string Tripdescreption { get; set; } = null!;

    public string Cityname { get; set; } = null!;

    public string Countryname { get; set; } = null!;

    public string Imgname { get; set; } = null!;

    public string Categoryname { get; set; } = null!;
}
