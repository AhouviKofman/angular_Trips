using System;
using System.Collections.Generic;

namespace dal.models;

public  class User
{
    public short IdUser { get; set; }

    public string? UserFirstName { get; set; }

    public string? UserLastName { get; set; }

    public string? UserPhone { get; set; }

    public string? UserMail { get; set; }

    public string? UserPassword { get; set; }

    public bool? UserFirstAid { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
