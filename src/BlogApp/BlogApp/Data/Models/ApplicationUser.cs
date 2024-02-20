// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ApplicationUser.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using Microsoft.AspNetCore.Identity;

namespace BlogApp.Data.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
	public static IdentityUser Instance { get; } = new ApplicationUser();
}