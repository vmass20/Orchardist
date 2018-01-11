using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orchardist.Data;

namespace Orchardist.Data
{
    public class OrchardDBContext : DbContext
    {
    public OrchardDBContext(DbContextOptions<OrchardDBContext> options)
    : base(options)
    {
    }
    public DbSet<GlobalPlantList> GlobalPlantList { get; set; }
    public DbSet<UserPlantList> UserPlantList { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<GlobalPlantList>().ToTable("GlobalPlantList");
      builder.Entity<UserPlantList>().ToTable("UserPlantList");
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);
    }
   
  }
}
