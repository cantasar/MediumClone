using Medium.Data.Abstract;
using Medium.Entity;

namespace Medium.Data.Concrete.EfCore;

public class EfPostRepository : IPostRepository
{
	private readonly BlogContext _context;
	public EfPostRepository(BlogContext context)
	{
		_context = context;
	}

	public IQueryable<Post> Posts => _context.Posts;

	public void AddPost(Post entity)
	{
		_context.Posts.Add(entity);
		_context.SaveChanges();
	}
}