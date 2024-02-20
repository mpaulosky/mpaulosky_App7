// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IDatabaseSettings.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

namespace BlogApp.Data.Interfaces;

public interface IDatabaseSettings
{
	string ConnectionStrings { get; init; }

	string DatabaseName { get; init; }
}