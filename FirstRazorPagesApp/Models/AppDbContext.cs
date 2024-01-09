using Microsoft.EntityFrameworkCore;

namespace FirstRazorPagesApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<CreditsModel> Credits { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
