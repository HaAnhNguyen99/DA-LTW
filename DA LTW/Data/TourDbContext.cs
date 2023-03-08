using DA_LTW.Models;
using Microsoft.EntityFrameworkCore;

namespace DA_LTW.Data
{
    public class TourDbContext : DbContext
    {
        public TourDbContext(DbContextOptions<TourDbContext> options) : base(options)
        {
        }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
