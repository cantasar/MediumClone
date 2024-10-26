using Medium.Data.Abstract;
using Medium.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
{
	var ConnectionString = builder.Configuration.GetConnectionString("SqliteConnection");
	options.UseSqlite(ConnectionString);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();

var app = builder.Build();

app.UseStaticFiles();

SeedData.SeedDatabase(app);

app.MapDefaultControllerRoute();

app.Run();
