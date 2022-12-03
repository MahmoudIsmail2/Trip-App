using System;
using System.Collections.Generic;

namespace Domains;

public partial class TbCity
{
    public int Cityid { get; set; }

    public string Cityname { get; set; } = null!;

    public string Countryname { get; set; } = null!;

    public virtual ICollection<TbTrip> TbTrips { get; } = new List<TbTrip>();
}
