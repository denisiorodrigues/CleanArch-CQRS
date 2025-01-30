using ClenaArch.Domain.Entities;
using ClenaArch.Infrastructure.EntityConffiguration;
using Microsoft.EntityFrameworkCore;

namespace ClenaArch.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
    }
}
