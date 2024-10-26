using Medium.Entity;

namespace Medium.Data.Abstract
{
	public interface ITagRepository
	{
		IQueryable<Tag> Tags { get; }

		void AddTag(Tag entity);
	}


}