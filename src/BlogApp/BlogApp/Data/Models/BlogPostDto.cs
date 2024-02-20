// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostDto.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using System.ComponentModel.DataAnnotations;

namespace BlogApp.Data.Models;

public class BlogPostDto
{
	public BlogPostDto()
	{
		
	}

	public BlogPostDto(BlogPostDto blogPostDto)
	{
		Url = blogPostDto.Url;
		Title = blogPostDto.Title;
		Description = blogPostDto.Description;
		Content = blogPostDto.Content;
		Author = blogPostDto.Author;
		Created = blogPostDto.Created;
		IsPublished = blogPostDto.IsPublished;
		Image = blogPostDto.Image;
		IsArchived = blogPostDto.IsArchived;
	}
	
	[Required]
	[StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
		MinimumLength = 1)]
	public string Url { get; set; } = "";

	[Required]
	[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
		MinimumLength = 1)]
	public string Title { get; set; } = "";

	[Required]
	[StringLength(200, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
		MinimumLength = 1)]
	public string Description { get; set; } = "";

	[Required]
	[StringLength(3000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
		MinimumLength = 1)]
	public string Content { get; set; } = "";

	public BasicUser Author { get; set; } = new();

	[Required]
	[DataType(DataType.DateTime)]
	public DateTime Created { get; set; } = DateTime.Now;

	[Required]
	[Display(Name = "Published")]
	public bool IsPublished { get; set; }

	public string Image { get; set; } = string.Empty;

	public bool IsArchived { get; set; }
}