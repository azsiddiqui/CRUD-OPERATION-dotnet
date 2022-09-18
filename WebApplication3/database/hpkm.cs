using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.database
{
    public class hpkm:DbContext
    {
        internal readonly object azsiddiqui;

        public hpkm(DbContextOptions<hpkm> options) : base(options) { }    
        public DbSet<dailysales> sales { get; set; }
        public DbSet<staff> staffs { get; set; }
    }
}
