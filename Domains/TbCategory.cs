using System;
using System.Collections.Generic;

namespace Domains;

public partial class TbCategory
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<TbTrip> TbTrips { get; } = new List<TbTrip>();
}
