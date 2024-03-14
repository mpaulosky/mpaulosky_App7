// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterAuthentication.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.RegisterServices;

public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Registers the necessary services for authentication.
	/// </summary>
	/// <param name="builder">The <see cref="WebApplicationBuilder" /> instance used to configure the application.</param>
	private static void RegisterAuthentication(this WebApplicationBuilder builder)
	{
		builder.Services.AddCascadingAuthenticationState();
		builder.Services.AddScoped<IdentityUserAccessor>();
		builder.Services.AddScoped<IdentityRedirectManager>();
		builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

		builder.Services.AddAuthentication(options =>
			{
				options.DefaultScheme = IdentityConstants.ApplicationScheme;
				options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
			})
			.AddIdentityCookies();

		builder.Services.AddAuthentication()
			.AddGoogle(googleOptions =>
			{
				var googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
				googleOptions.ClientId = googleAuthNSection["ClientId"] ?? string.Empty;
				googleOptions.ClientSecret = googleAuthNSection["ClientSecret"] ?? string.Empty;
			})
			.AddMicrosoftAccount(microsoftOptions =>
			{
				var microsoftAuthNSection = builder.Configuration.GetSection("Authentication:Microsoft");
				microsoftOptions.ClientId = microsoftAuthNSection["ClientId"] ?? string.Empty;
				microsoftOptions.ClientSecret = microsoftAuthNSection["ClientSecret"] ?? string.Empty;
			});
	}
}