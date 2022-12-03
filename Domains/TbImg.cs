using System;
using System.Collections.Generic;

namespace Domains;

public partial class TbImg
{
    public int Imgid { get; set; }

    public string Imgname { get; set; } = null!;

    public virtual ICollection<TbTrip> TbTrips { get; } = new List<TbTrip>();
}
