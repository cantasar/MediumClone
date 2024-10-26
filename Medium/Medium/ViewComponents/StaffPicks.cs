using Medium.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medium.ViewComponents
{
	public class StaffPicks : ViewComponent
	{
		private IPostRepository _postRepository;
		public StaffPicks(IPostRepository tagRepository)
		{
			_postRepository = tagRepository;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View( await
				_postRepository
				.Posts
				.OrderByDescending(p => p.PublishedOn)
				.Take(3)
				.ToListAsync()
				);
		}
	}

}