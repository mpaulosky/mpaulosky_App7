// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterAll.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

namespace BlogApp.RegisterServices;
[ExcludeFromCodeCoverage]
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Configures services for the web application.
	/// </summary>
	/// <param name="builder">The web application builder.</param>
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.RegisterApplicationComponents();

		builder.RegisterAuthentication();

		builder.RegisterIdentityServer();

		builder.RegisterMongoDbContextFactory();

		builder.RegisterDataSources();
	}
}