using Asp2017.Server.Models;
using AspCoreServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreServer.Data
{
    public class SpaDbContext : DbContext
    {
        public SpaDbContext(DbContextOptions<SpaDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        //List of DB Models - Add your DB models here
        public DbSet<Estimate> Estimates { get; set; }
    }
}
