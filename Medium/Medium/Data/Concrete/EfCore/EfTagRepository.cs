using Medium.Data.Abstract;
using Medium.Entity;

namespace Medium.Data.Concrete.EfCore;

public class EfTagRepository : ITagRepository
{
	private readonly BlogContext _context;
	public EfTagRepository(BlogContext context)
	{
		_context = context;
	}

	public IQueryable<Tag> Tags => _context.Tags;

	public void AddTag(Tag entity)
	{
		_context.Tags.Add(entity);
		_context.SaveChanges();
	}
}