using Medium.Data.Abstract;
using Medium.Data.Concrete.EfCore;
using Medium.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medium.Controllers;

public class PostsController : Controller
{
	private IPostRepository _postRepository;
	private ICommentRepository _commentRepository;
	public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
	{
		_postRepository = postRepository;
		_commentRepository = commentRepository;
	}

	public async Task<IActionResult> Index(string tag)
	{
		var posts = _postRepository.Posts;
		if(!string.IsNullOrEmpty(tag))
		{
			posts = posts.Where(p => p.Tags.Any(t => t.Url == tag));
		}
		return View(
			new PostsViewModel
			{
				Posts = await posts.ToListAsync()
			}
		);
	}

	public async Task<IActionResult> Details(string url)
	{
		return View(await _postRepository
			.Posts
			.Include(p => p.Tags)
			.Include(p => p.Comments)
			.ThenInclude(p => p.User)
			.FirstOrDefaultAsync(p => p.Url == url)
		);
	}

	public IActionResult AddComment(int PostId, string UserName, string Text, string Url)
	{
		var entity = new Comment
		{
			Text = Text,
			PublishedOn = DateTime.Now,
			PostId = PostId,
			User = new User { UserName = UserName, Image = "user.png" }
		};
		_commentRepository.AddComment(entity);
		return Redirect("/posts/details/" + Url);
	}

}
