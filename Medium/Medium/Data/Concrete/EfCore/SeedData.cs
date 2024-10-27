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
					new Tag { Text = "C#", Url = "csharp" },
					new Tag { Text = "ASP.NET Core", Url = "aspnet-core" },
					new Tag { Text = "Entity Framework Core", Url = "ef-core" },
					new Tag { Text = "SQL", Url = "sql" },
					new Tag { Text = "Python", Url = "python" },
					new Tag { Text = "Django", Url = "django" },
					new Tag { Text = "Java", Url = "java" },
					new Tag { Text = "Spring", Url = "spring" },
					new Tag { Text = "JavaScript", Url = "javascript" },
					new Tag { Text = "React", Url = "react" },
					new Tag { Text = "Angular", Url = "angular" },
					new Tag { Text = "Vue", Url = "vue" },
					new Tag { Text = "Node.js", Url = "nodejs" }
				);
				context.SaveChanges();
			}

			if(!context.Users.Any())
			{
				context.Users.AddRange(
					new User { UserName = "User1", Image = "user.png" },
					new User { UserName = "User2", Image = "user.png" },
					new User { UserName = "User3", Image = "user.png" }
				);
				context.SaveChanges();
			}

			if(!context.Posts.Any())
			{
				var random = new Random();
				context.Posts.AddRange(
					new Post
					{
						Title = "Post 1",
						Content = "Content 1",
						Url = "post-1",
						UserId = 2,
						Tags = context.Tags.Take(3).ToList(),
						IsActive = true,
						PublishedOn = DateTime.Now.AddDays(-1),
						Image = "1.png",
						Comments = new List<Comment>{
							new Comment {
								Text = "Comment 1",
								PublishedOn = DateTime.Now,
								UserId = 1
							}
						}
					},
					new Post
					{
						Title = "Post 2",
						Content = "Content 2",
						Url = "post-2",
						UserId = context.Users.Skip(1).First().UserId,
						Tags = context.Tags.Take(3).ToList(),
						IsActive = true,
						PublishedOn = DateTime.Now.AddDays(random.Next(-30, 0)),
						Image = "2.png"
					},
					new Post
					{
						Title = "Post 3",
						Content = "Content 3",
						Url = "post-3",
						UserId = context.Users.Skip(2).First().UserId,
						Tags = context.Tags.Take(3).ToList(),
						IsActive = true,
						PublishedOn = DateTime.Now.AddDays(random.Next(-30, 0)),
						Image = "3.png"
					},
					new Post
					{
						Title = "Post 4",
						Content = "Content 4",
						Url = "post-4",
						UserId = context.Users.First().UserId,
						Tags = context.Tags.Take(3).ToList(),
						IsActive = true,
						PublishedOn = DateTime.Now.AddDays(random.Next(-30, 0)),
						Image = "4.png"
					},
					new Post
					{
						Title = "Post 5",
						Content = "Content 5",
						Url = "post-5",
						UserId = context.Users.Skip(1).First().UserId,
						Tags = context.Tags.Take(3).ToList(),
						IsActive = true,
						PublishedOn = DateTime.Now.AddDays(random.Next(-30, 0)),
						Image = "5.png"
					},
					new Post
					{
						Title = "Post 6",
						Content = "Content 6",
						Url = "post-6",
						UserId = context.Users.Skip(2).First().UserId,
						Tags = context.Tags.Take(3).ToList(),
						IsActive = true,
						PublishedOn = DateTime.Now.AddDays(random.Next(-30, 0)),
						Image = "6.png"
					}
				);
				context.SaveChanges();
			}

		}
	}
}
