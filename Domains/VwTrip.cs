using System;
using System.Collections.Generic;

namespace Domains;

public partial class VwTrip
{
    public string Tripname { get; set; } = null!;

    public decimal Tripprice { get; set; }

    public string Tripdescreption { get; set; } = null!;

    public string Imgname { get; set; } = null!;

    public string Categoryname { get; set; } = null!;

    public int Tripid { get; set; }

    public int Imgid { get; set; }

    public int Cityid { get; set; }

    public string Cityname { get; set; } = null!;

    public string Countryname { get; set; } = null!;

    public int Categoryid { get; set; }
}
