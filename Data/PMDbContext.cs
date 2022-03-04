using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManage.Models;

namespace ProjectManage.Data
{
    public class PMDbContext : IdentityDbContext<ApplicationUser>
    {
        public PMDbContext(DbContextOptions<PMDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<UserProject>().HasKey(c => new { c.ProjectId, c.UserId});
        }

        public DbSet<Jab>? Jabs { get; set; }
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<UserProject>? UserProject { get; set; }
    }
}