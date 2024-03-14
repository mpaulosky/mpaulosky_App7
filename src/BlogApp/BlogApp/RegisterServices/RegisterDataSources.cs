// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterDataSources.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using BlogApp.Data.Interfaces;
using BlogApp.Data.Repositories;
using BlogApp.Data.Services;

namespace BlogApp.RegisterServices;

public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Register DataSources
	/// </summary>
	/// <param name="builder"></param>
	private static void RegisterDataSources(this WebApplicationBuilder builder)
	{
		// Add services to the container.
		builder.Services.AddSingleton<IBlogRepository, BlogRepository>();
		builder.Services.AddSingleton<IBlogService, BlogService>();
	}
}