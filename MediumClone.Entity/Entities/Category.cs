using System;
using MediumClone.Core.Entities;

namespace MediumClone.Entity.Entities;

public class Category : EntityBase
{
	public string Name { get; set; }
	public ICollection<Article> Articles { get; set; }
}