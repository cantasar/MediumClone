using System.Reflection.Metadata.Ecma335;
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
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();

var app = builder.Build();

app.UseStaticFiles();

SeedData.SeedDatabase(app);

app.MapControllerRoute(
	name: "post_details",
	pattern: "posts/details/{url}",
	defaults: new { controller = "Posts", action = "Details" }
);

app.MapControllerRoute(
	name: "posts_by_tag",
	pattern: "posts/tag/{tag}",
	defaults: new { controller = "Posts", action = "Index" }
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Posts}/{action=Index}/{id?}"
);

app.Run();
