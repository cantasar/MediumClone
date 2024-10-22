using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediumClone.Entity.Entities;

namespace MediumClone.Data.Mappings;

public class ImageMap : IEntityTypeConfiguration<Image>
{
	public void Configure(EntityTypeBuilder<Image> builder)
	{
		builder.HasData(
			new Image
			{
				Id = Guid.Parse("c4d3e4b4-7a1f-4c4d-9d2c-5e6f7b8a9d0b"),
				FileName = "Image 1",
				FileType = "image/png",
				CreatedAt = DateTime.Now,
				IsDeleted = false,
				CreatedBy = "Admin"
			}
			// ,
			// new Image
			// {
			// 	Id = Guid.Parse("f4b3f3b3-6b9f-4b3b-8b1b-3f3b6b9f4b3c"),
			// 	FileName = "Image 2",
			// 	FileType = "image/png",
			// 	CreatedAt = DateTime.Now,
			// 	IsDeleted = false,
			// 	CreatedBy = "Admin2"
			// }
		);
	}

}
