// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterDbContextFactory.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using BlogApp.Data;
using BlogApp.Data.Interfaces;
using BlogApp.Data.Models;

namespace BlogApp.RegisterServices;

public static partial class ServiceCollectionExtensions
{
	private static void RegisterMongoDbContextFactory(this WebApplicationBuilder builder)
	{
		// Get the MongoDbSettings section from the appsettings.json file.
		IConfigurationSection section = builder.Configuration.GetSection("MongoDbSettings")
		                                ?? throw new InvalidOperationException("Section 'MongoDbSettings' not found.");

		// Get the DatabaseSettings from the appsettings.json file.
		DatabaseSettings mongoSettings = section.Get<DatabaseSettings>() ??
		                                 throw new ArgumentNullException(nameof(mongoSettings.DatabaseName));

		// Register the IDatabaseSettings with the DI container.
		builder.Services.AddSingleton<IDatabaseSettings>(mongoSettings);
		
		builder.Services.AddSingleton<IMongoDbContextFactory, MongoDbContextFactory>();
	}
}