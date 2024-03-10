using dal.interfaces;
using dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
    public interface Icontext
    {
        
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<TripsType> tripsTypes { get; set; }
        public DbSet<models.User> users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
