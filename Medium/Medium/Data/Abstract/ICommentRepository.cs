using Medium.Entity;

namespace Medium.Data.Abstract
{
	public interface ICommentRepository
	{
		IQueryable<Comment> Comments { get; }

		void AddComment(Comment entity);
	}


}