// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPost.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using System.ComponentModel.DataAnnotations;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApp.Data.Models;

/// <summary>
///   Class for storing data for a blog post.
/// </summary>
[Serializable]
public class BlogPost
{
	public BlogPost()
	{
		
	}
	public BlogPost(BlogPost? blogPost)
	{
		Id = blogPost?.Id;
		ObjectIdentifier = blogPost?.ObjectIdentifier;
		Url = blogPost?.Url;
		Title = blogPost?.Title;
		Content = blogPost?.Content;
		Created = blogPost?.Created;
		Updated = blogPost?.Updated;
		Author = blogPost?.Author;
		Description = blogPost?.Description;
		Image = blogPost?.Image;
		IsPublished = blogPost?.IsPublished;
		IsArchived = blogPost?.IsArchived;
		ArchivedBy = blogPost?.ArchivedBy;
	}

	/// <summary>
	///   Gets or sets the ID of the blog post.
	/// </summary>
	[BsonId]
	[BsonElement("_id")]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? Id { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the object identifier.
	/// </summary>
	/// <value>
	///   The object identifier.
	/// </value>
	[BsonElement("object_identifier")]
	public string? ObjectIdentifier { get; set; } = string.Empty;
	
	/// <summary>
	///   Gets or sets the URL of the blog post.
	/// </summary>
	[BsonElement("url")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(100)]
	public string? Url { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the title of the blog post.
	/// </summary>
	[BsonElement("title")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(256)]
	public string? Title { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the content of the blog post.
	/// </summary>
	[BsonElement("content")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(100000)]
	public string? Content { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the date the blog post was created.
	/// </summary>
	[BsonElement("date_created")]
	[BsonRepresentation(BsonType.DateTime)]
	public DateTimeOffset? Created { get; set; }

	/// <summary>
	///   Gets or sets the date the blog post was updated.
	/// </summary>
	[BsonElement("date_updated")]
	[BsonRepresentation(BsonType.DateTime)]
	public DateTimeOffset? Updated { get; set; }

	/// <summary>
	///   Gets or sets the name of the author of the blog post.
	/// </summary>
	public BasicUser? Author { get; set; } = new();

	/// <summary>
	///   Gets or sets the description for the blog post.
	/// </summary>
	[BsonElement("description")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(256)]
	public string? Description { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the image associated with the blog post.
	/// </summary>
	[BsonElement("image")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(1000)]
	public string? Image { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets a value indicating whether the blog post is published.
	/// </summary>
	[BsonElement("is_published")]
	[BsonRepresentation(BsonType.Boolean)]
	public bool? IsPublished { get; set; }

	/// <summary>
	///   Gets or sets a value indicating whether the blog post has been deleted.
	/// </summary>
	[BsonElement("is_archived")]
	[BsonRepresentation(BsonType.Boolean)]
	public bool? IsArchived { get; set; } = false;

	/// <summary>
	///   Gets or sets who archived the record.
	/// </summary>
	/// <value>
	///   Who archived the record.
	/// </value>
	public BasicUser? ArchivedBy { get; set; } = new();
}