using Medium.Entity;
using Microsoft.EntityFrameworkCore;

namespace Medium.Data.Concrete.EfCore;

public class SeedData
{
	public static void SeedDatabase(IApplicationBuilder app)
	{
		var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BlogContext>();

		if (context != null)
		{
			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}

			if(!context.Tags.Any())
			{
				context.Tags.AddRange(
					new Tag { Text = "C#" },
					new Tag { Text = "ASP.NET Core" },
					new Tag { Text = "Entity Framework Core" },
					new Tag { Text = "SQL" }
				);
				context.SaveChanges();
			}

			if(!context.Users.Any())
			{
				context.Users.AddRange(
					new User { UserName = "User1" },
					new User { UserName = "User2" },
					new User { UserName = "User3" }
				);
				context.SaveChanges();
			}

			if(!context.Posts.Any())
			{
				context.Posts.AddRange(
					new Post
					{
						Title = "Post 1",
						Content = "Content 1",
						UserId = context.Users.First().UserId,
						Tags = new List<Tag> { context.Tags.First() },
						IsActice = true
					},
					new Post
					{
						Title = "Post 2",
						Content = "Content 2",
						UserId = context.Users.Skip(1).First().UserId,
						Tags = new List<Tag> { context.Tags.Skip(1).First() }
					},
					new Post
					{
						Title = "Post 3",
						Content = "Content 3",
						UserId = context.Users.Skip(2).First().UserId,
						Tags = new List<Tag> { context.Tags.Skip(2).First() }
					}
				);
				context.SaveChanges();
			}

		}
	}
}
