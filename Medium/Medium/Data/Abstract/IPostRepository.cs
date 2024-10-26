using Medium.Entity;

namespace Medium.Data.Abstract
{
	public interface IPostRepository
	{
		IQueryable<Post> Posts { get; }

		void AddPost(Post entity);
	}


}