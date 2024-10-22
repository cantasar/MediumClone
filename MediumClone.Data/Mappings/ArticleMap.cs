using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediumClone.Entity.Entities;

namespace MediumClone.Data.Migrations;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
		builder.HasData(
			new Article
			{
				Id = Guid.NewGuid(),
				Title = "Article 1",
				Content = "Content 1",
				ViewCount = 15,
				CategoryId = Guid.Parse("c4d3e4b4-7a1f-4c4d-9d2c-5e6f7b8a9d0b"),
				ImageId = Guid.Parse("c4d3e4b4-7a1f-4c4d-9d2c-5e6f7b8a9d0b"),
				CreatedAt = DateTime.Now,
				IsDeleted = false,
				CreatedBy = "Admin"
			}
			// ,
			// new Article
			// {
			// 	Id = Guid.NewGuid(),
			// 	Title = "Article 2",
			// 	Content = "Content 2",
			// 	ViewCount = 25,
			// 	CategoryId = Guid.Parse("c4d3e4b4-7a1f-4c4d-9d2c-5e6f7b8a9d0b"),
			// 	ImageId = Guid.Parse("a3f5e9b8-0f3d-4c8c-9b7a-e6d4f2b1a1f7"),
			// 	CreatedAt = DateTime.Now,
			// 	IsDeleted = false,
			// 	CreatedBy = "Admin2"
			// } 
		);
    }
}
