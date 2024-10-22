using System;
using MediumClone.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MediumClone.Data.Mappings;

public class CategoryMap: IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasData(
			new Category
			{
				Id = Guid.Parse("c4d3e4b4-7a1f-4c4d-9d2c-5e6f7b8a9d0b"),
				Name = "Category 1",
				IsDeleted = false,
				CreatedAt = DateTime.Now,
				CreatedBy = "Admin"
			}
			// ,
			// new Category
			// {
			// 	Id = Guid.Parse("f4b3f3b3-6b9f-4b3b-8b1b-3f3b6b9f4b3c"),
			// 	Name = "Category 2",
			// 	IsDeleted = false,
			// 	CreatedAt = DateTime.Now,
			// 	CreatedBy = "Admin2"
			// }
		);
	}
}
