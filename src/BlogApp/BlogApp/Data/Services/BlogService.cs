// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogService.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using BlogApp.Data.Interfaces;
using BlogApp.Data.Models;

namespace BlogApp.Data.Services;

/// <summary>
/// Represents a service for managing blog posts.
/// </summary>
public class BlogService : IBlogService
{
	private readonly IBlogRepository _data;

	/// <summary>
	///   Initializes a new instance of the <see cref="BlogService" /> class with an instance of
	///   <see cref="IBlogRepository" />.
	/// </summary>
	/// <param name="data">The <see cref="IBlogRepository" /> instance to be used by this class.</param>
	public BlogService(IBlogRepository data)
	{
		_data = data;
	}

	/// <summary>
	///   Archives the specified blog post.
	/// </summary>
	/// <param name="post">The blog post to be archived.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	public Task ArchiveAsync(BlogPost? post)
	{
		ArgumentNullException.ThrowIfNull(post);

		return _data.ArchiveAsync(post);
	}

	/// <summary>
	///   Creates a new blog post.
	/// </summary>
	/// <param name="post">The blog post to be created.</param>
	/// <returns>
	///   A task that represents the asynchronous operation. The task result contains the created
	///   <see cref="BlogPost" /> instance.
	/// </returns>
	public Task CreateAsync(BlogPost? post)
	{
		ArgumentNullException.ThrowIfNull(post);

		return _data.CreateAsync(post);
	}

	/// <summary>
	///   Gets all the blog posts.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result contains a list of all the blog posts.</returns>
	public async Task<List<BlogPost>?> GetAllAsync()
	{
		return await _data.GetAllAsync() as List<BlogPost>;
	}

	/// <summary>
	///  Gets the blog post by the specified Id..
	/// </summary>
	/// <param name="id"></param>
	/// <returns>
	///   A task that represents the asynchronous operation. The task result contains the retrieved
	///   <see cref="BlogPost" /> instance.
	/// </returns>
	public async Task<BlogPost?> GetByIdAsync(string? id)
	{
		if (string.IsNullOrEmpty(id))
		{
			throw new ArgumentNullException(nameof(id));
		}
    
		return await _data.GetByIdAsync(id);
	}

	/// <summary>
	///   Gets the blog post by the specified URL.
	/// </summary>
	/// <param name="url">The URL of the blog post to be retrieved.</param>
	/// <returns>
	///   A task that represents the asynchronous operation. The task result contains the retrieved
	///   <see cref="BlogPost" /> instance.
	/// </returns>
	public async Task<BlogPost?> GetByUrlAsync(string? url)
	{
		if (string.IsNullOrEmpty(url))
		{
			throw new ArgumentNullException(nameof(url));
		}
		
		return await _data.GetByUrlAsync(url);
	}

	/// <summary>
	/// Retrieves a list of blog posts by author ID.
	/// </summary>
	/// <param name="authorId">The ID of the author.</param>
	/// <returns>A task that represents the asynchronous operation.
	/// The task result contains a list of blog posts by the author ID.</returns>
	public async Task<List<BlogPost?>> GetByAuthorIdAsync(string? authorId)
	{
		if (string.IsNullOrEmpty(authorId))
		{
			throw new ArgumentNullException(nameof(authorId));
		}
		
		return (await _data.GetByAuthorIdAsync(authorId)).ToList();
	}

	/// <summary>
	/// Retrieves a list of blog posts that are published.
	/// </summary>
	/// <param name="published">Optional. Indicates whether to retrieve published blog posts (true by default).</param>
	/// <returns>
	/// A task that represents the asynchronous operation. The task result contains a collection of <see cref="BlogPost"/> objects that match the specified criteria,
	/// or null if no matches are found.
	/// </returns>
	public async Task<IEnumerable<BlogPost?>> GetByPublishedAsync(bool published = true)
	{
		return await _data.GetByPublishedAsync(published);
	}

	/// <summary>
	/// Retrieves a list of blog posts by their archived status.
	/// </summary>
	/// <param name="archived">The archived status of the blog posts. The default value is true.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains a list of blog posts (IEnumerable{BlogPost}) or null if no posts are found.</returns>
	public async Task<IEnumerable<BlogPost?>> GetByArchivedAsync(bool archived = true)
	{
		return await _data.GetByArchivedAsync(archived);
	}

	/// <summary>
	/// Retrieves a blog post by its title asynchronously.
	/// </summary>
	/// <param name="title">The title of the blog post to retrieve.</param>
	/// <returns>
	/// A task representing the asynchronous operation. The task result contains the blog post
	/// with the specified title, or null if no blog post is found.
	/// </returns>
	public async Task<BlogPost?> GetByTitleAsync(string? title)
	{
		if (string.IsNullOrEmpty(title))
		{
			throw new ArgumentNullException(nameof(title));
		}
		
		return await _data.GetByTitleAsync(title);
	}

	/// <summary>
	///   Updates the specified blog post.
	/// </summary>
	/// <param name="post">The blog post to be updated.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	public Task UpdateAsync(BlogPost? post)
	{
		ArgumentNullException.ThrowIfNull(post);

		return _data.UpdateAsync(post.Id, post);
	}
}