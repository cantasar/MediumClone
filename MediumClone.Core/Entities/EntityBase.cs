using System;

namespace MediumClone.Core.Entities;

public abstract class EntityBase : IEntityBase
{
	public virtual Guid Id { get; set; } = Guid.NewGuid();
	public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
	public virtual DateTime? UpdatedAt { get; set; }
	public virtual DateTime? DeletedAt { get; set; }
	public virtual string CreatedBy { get; set; }
	public virtual string? UpdatedBy { get; set; }
	public virtual string? DeletedBy { get; set; }
	public virtual bool IsDeleted { get; set; } = false;
}
