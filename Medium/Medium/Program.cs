using Medium.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
{
	var ConnectionString = builder.Configuration.GetConnectionString("SqliteConnection");
	options.UseSqlite(ConnectionString);
});
var app = builder.Build();

SeedData.SeedDatabase(app);

app.MapDefaultControllerRoute();

app.Run();
