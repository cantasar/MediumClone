using System;

namespace Medium.Entity;

public class User
{
	public int UserId { get; set; }
	public string? UserName { get; set; }
	public string? Image { get; set; }

	public List<Post> Posts { get; set; } = [];

	public List<Comment> Comments { get; set; } = [];
}
