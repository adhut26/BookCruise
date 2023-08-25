using BookingCruise.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingCruise.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)    
        {

        }
        public DbSet<CruiseBook> CruiseBooks { get; set;}       
    }
}
