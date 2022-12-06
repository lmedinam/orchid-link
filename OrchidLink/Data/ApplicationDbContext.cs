using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrchidLink.Models;
using System.Reflection.Emit;

namespace OrchidLink.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Link> Links { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Link>()
                .HasIndex(e => e.Slug)
                .IsUnique();
        }
    }
}