using System;
using System.Collections.Generic;

namespace dal.models;

public  class TripsType
{
    public short IdType { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
}
