using Microsoft.EntityFrameworkCore;
using SectraDataApp.Models;

namespace SectraDataApp.Data;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<SiteInfo>SiteInfos { get; set; }
    }

