// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     DatabaseSettings.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using BlogApp.Data.Interfaces;

namespace BlogApp.Data.Models;

/// <summary>
///   DatabaseSettings class
/// </summary>
public class DatabaseSettings(string connectionStrings, string databaseName) : IDatabaseSettings
{
	public string ConnectionStrings { get; init; } = connectionStrings;

	public string DatabaseName { get; init; } = databaseName;
}