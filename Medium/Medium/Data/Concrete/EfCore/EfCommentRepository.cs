using Medium.Data.Abstract;
using Medium.Entity;

namespace Medium.Data.Concrete.EfCore;

public class EfCommentRepository : ICommentRepository
{
	private readonly BlogContext _context;
	public EfCommentRepository(BlogContext context)
	{
		_context = context;
	}

	public IQueryable<Comment> Comments => _context.Comments;

	public void AddComment(Comment entity)
	{
		_context.Comments.Add(entity);
		_context.SaveChanges();
	}
}