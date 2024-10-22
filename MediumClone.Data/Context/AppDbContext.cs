using Microsoft.EntityFrameworkCore;
using MediumClone.Entity.Entities;
using System.Reflection;

namespace MediumClone.Data.Context;

public class AppDbContext: DbContext
{
	public AppDbContext()
	{
	}
	public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
	{
	}

	public DbSet<MediumClone.Entity.Entities.Article> Articles { get; set; }
	public DbSet<MediumClone.Entity.Entities.Category> Categories { get; set; }
	public DbSet<MediumClone.Entity.Entities.Image> Images { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
