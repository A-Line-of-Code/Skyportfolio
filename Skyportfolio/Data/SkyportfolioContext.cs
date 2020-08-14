using Microsoft.EntityFrameworkCore;
using Skyportfolio.Models;

namespace Skyportfolio.Data
{
    public class SkyportfolioContext : DbContext
    {
        public SkyportfolioContext(DbContextOptions<SkyportfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
