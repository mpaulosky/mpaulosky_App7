using BlogApp.Data.Interfaces;
using BlogApp.Data.Models;

using MongoDB.Bson;
using MongoDB.Driver;

namespace BlogApp.Data.Repositories;

///<summary>
/// This is a repository class for blog posts handling typical CRUD operations and several specific queries.
/// Author: teqsl
///</summary>
public class BlogRepository : IBlogRepository
{
	private readonly IMongoCollection<BlogPost?> _blogCollection;
	
	/// <summary>
	///   Constructs a new instance of BlogRepository, initializing the database context and collection for BlogPost items.
	/// </summary>
	/// <param name="context">The database context used for operations with MongoDB</param>
	/// <exception cref="ArgumentNullException">Thrown if context is null.</exception>
	public BlogRepository(IMongoDbContextFactory context)
	{
		string blogCollectionName = GetCollectionName(nameof(BlogPost));
		_blogCollection = context.GetCollection<BlogPost>(blogCollectionName);
	}

	
	/// <summary>
	///   Archives the provided post in the database.
	/// </summary>
	/// <param name="post">The BlogPost instance to archive.</param>
	/// <returns>Task for the asynchronous operation.</returns>
	public async Task ArchiveAsync(BlogPost? post)
	{
		ArgumentNullException.ThrowIfNull(post);

		await UpdateAsync(post.Id, post);
	}

	/// <summary>
	///   Asynchronously creates a new blog post in the database.
	/// </summary>
	/// <param name="post">The blog post to create.</param>
	/// <exception cref="Exception">Thrown if an error occurs during the operation.</exception>
	public async Task CreateAsync(BlogPost? post)
	{
		ArgumentNullException.ThrowIfNull(post);

		await _blogCollection.InsertOneAsync(post);
	}

	/// <summary>
	///   Asynchronously gets a blog post by its id.
	/// </summary>
	/// <param name="itemId">The id of the blog post to retrieve.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the blog post if found.</returns>
	public async Task<BlogPost?> GetByIdAsync(string? itemId)
	{
		if (string.IsNullOrWhiteSpace(itemId))
		{
			throw new ArgumentNullException(nameof(itemId));
		}

		ObjectId objectId = new(itemId);

		FilterDefinition<BlogPost> filter = Builders<BlogPost>.Filter.Eq("_id", objectId);

		BlogPost? result = (await _blogCollection!.FindAsync(filter)).FirstOrDefault();

		return result;
	}

	/// <summary>
	///   Asynchronously gets a blog post by its url.
	/// </summary>
	/// <param name="url">The url of the blog post to retrieve.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the blog post if found.</returns>
	public async Task<BlogPost?> GetByUrlAsync(string? url)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			throw new ArgumentNullException(nameof(url));
		}

		FilterDefinition<BlogPost> filter = Builders<BlogPost>.Filter.Eq("url", url);

		BlogPost? result = (await _blogCollection!.FindAsync(filter)).FirstOrDefault();

		return result;
	}
	
	/// <summary>
	///   Asynchronously gets a blog post by its title.
	/// </summary>
	/// <param name="title">The title of the blog post to retrieve.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the blog post if found.</returns>
	public async Task<BlogPost?> GetByTitleAsync(string? title)
	{
		if (string.IsNullOrWhiteSpace(title))
		{
			throw new ArgumentNullException(nameof(title));
		}

		FilterDefinition<BlogPost> filter = Builders<BlogPost>.Filter.Eq("Title", title);

		BlogPost? result = (await _blogCollection!.FindAsync(filter)).FirstOrDefault();

		return result;
	}

	/// <summary>
	///   Asynchronously gets blog posts by their published status.
	/// </summary>
	/// <param name="published">Indicates whether to retrieve published blog posts. Default is true.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the blog posts if found.</returns>
	public async Task<IEnumerable<BlogPost?>> GetByPublishedAsync(bool published = true)
	{
		FilterDefinition<BlogPost> filter = Builders<BlogPost>.Filter.Eq("IsPublished", published);

		List<BlogPost> results = (await _blogCollection!.FindAsync(filter)).ToList();

		return results;
	}

	/// <summary>
	///   Asynchronously gets blog posts by their archived status.
	/// </summary>
	/// <param name="archived">Indicates whether to retrieve archived blog posts. Default is true.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the blog posts if found.</returns>
	public async Task<IEnumerable<BlogPost?>> GetByArchivedAsync(bool archived = true)
	{
		FilterDefinition<BlogPost> filter = Builders<BlogPost>.Filter.Eq("IsArchived", archived);

		List<BlogPost> results = (await _blogCollection!.FindAsync(filter)).ToList();

		return results;
	}

	/// <summary>
	///   Asynchronously gets all blog posts.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result contains the blog posts if found.</returns>
	public async Task<IEnumerable<BlogPost?>> GetAllAsync()
	{
		FilterDefinition<BlogPost> filter = Builders<BlogPost>.Filter.Empty;

		List<BlogPost> results = (await _blogCollection!.FindAsync(filter)).ToList();

		return results;
	}

	/// <summary>
	///   Asynchronously gets blog posts by the provided author ID.
	/// </summary>
	/// <param name="authorId">The ID of the author whose posts to retrieve.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the blog posts if found.</returns>
	public async Task<IEnumerable<BlogPost?>> GetByAuthorIdAsync(string? authorId)
	{
		if (string.IsNullOrWhiteSpace(authorId))
		{
			throw new ArgumentNullException(nameof(authorId));
		}
		
		List<BlogPost> results = (await _blogCollection.FindAsync(s => s.Author.Id == authorId)).ToList();

		return results;
	}

	/// <summary>
	///   Asynchronously updates a blog post in the database.
	/// </summary>
	/// <param name="postId">The id of the blog post to update.</param>
	/// <param name="post">The updated blog post.</param>
	public async Task UpdateAsync(string? postId, BlogPost? post)
	{
		if (string.IsNullOrWhiteSpace(postId))
		{
			throw new ArgumentNullException(nameof(postId));
		}
		
		if (post == null)
		{
			throw new ArgumentNullException(nameof(post));
		}

		ObjectId objectId = new(postId);

		FilterDefinition<BlogPost> filter = Builders<BlogPost>.Filter.Eq("_id", objectId);

		await _blogCollection.ReplaceOneAsync(filter!, post);
	}
}