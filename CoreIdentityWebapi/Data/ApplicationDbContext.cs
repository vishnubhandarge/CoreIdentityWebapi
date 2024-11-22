using CoreIdentityWebapi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedRoles(modelBuilder);
    }

    private static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Name = "Admin",ConcurrencyStamp="1", NormalizedName = "ADMIN" },
            new IdentityRole() { Name = "User",ConcurrencyStamp="2", NormalizedName = "USER" },
            new IdentityRole() { Name = "HR",ConcurrencyStamp="3", NormalizedName = "HR" }
        );
    }
}
