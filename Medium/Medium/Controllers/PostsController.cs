using Medium.Data.Abstract;
using Medium.Data.Concrete.EfCore;
using Medium.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Medium.Controllers;

public class PostsController : Controller
{
	private IPostRepository _postRepository;
	public PostsController(IPostRepository postRepository)
	{
		_postRepository = postRepository;
	}

	public IActionResult Index()
	{
		return View(
			new PostsViewModel
			{
				Posts = _postRepository.Posts.ToList()
			}
		);
	}

}
