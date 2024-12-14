using Microsoft.EntityFrameworkCore;

namespace STUDMANAG.SContext
{
    public class SDbcontext : DbContext
    {
        public SDbcontext(DbContextOptions<SDbcontext> options) : base(options) { }
        //public DbSet
    }
}
