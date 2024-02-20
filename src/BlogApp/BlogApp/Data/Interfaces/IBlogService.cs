﻿// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IBlogService.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using BlogApp.Data.Models;

namespace BlogApp.Data.Interfaces;

public interface IBlogService
{
	Task ArchiveAsync(BlogPost? post);

	Task CreateAsync(BlogPost? post);

	Task<List<BlogPost>?> GetAllAsync();
	
	Task<BlogPost?> GetByIdAsync(string? id);
	
	Task<BlogPost?> GetByUrlAsync(string? url);
	
	Task<BlogPost?> GetByTitleAsync(string? title);
	
	Task<List<BlogPost?>> GetByAuthorIdAsync(string? authorId);


	Task<IEnumerable<BlogPost?>> GetByPublishedAsync(bool published = true);

	Task<IEnumerable<BlogPost?>> GetByArchivedAsync(bool archived = true);

	Task UpdateAsync(BlogPost? post);
}