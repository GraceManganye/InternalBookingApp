using Microsoft.EntityFrameworkCore;
using InternalBookingApp.Models;//allows created models to be used in this database class

namespace InternalBookingApp.Data
{
    // this inherits from DbContext
    public class InternalBookingAppContext : DbContext
    {
        public InternalBookingAppContext(DbContextOptions<InternalBookingAppContext> options)
            : base(options) { }

          public DbSet<Resource> Resources { get; set; }//adds resource model to database
          public DbSet<Booking> Bookings { get; set; }//adds booking model to database
    }
}
