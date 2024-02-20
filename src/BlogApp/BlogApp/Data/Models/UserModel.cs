// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserModel.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

namespace BlogApp.Data.Models;

/// <summary>
///   UserModel class
/// </summary>
public class UserModel
{
	/// <summary>
	///   Gets or sets the identifier.
	/// </summary>
	/// <value>
	///   The identifier.
	/// </value>
	public string Id { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the object identifier.
	/// </summary>
	/// <value>
	///   The object identifier.
	/// </value>
	public string ObjectIdentifier { get; set; } = string.Empty;
	
	/// <summary>
	///   Gets or sets the first name.
	/// </summary>
	/// <value>
	///   The first name.
	/// </value>
	public string FirstName { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the last name.
	/// </summary>
	/// <value>
	///   The last name.
	/// </value>
	public string LastName { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the display name.
	/// </summary>
	/// <value>
	///   The display name.
	/// </value>
	public string DisplayName { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the email address.
	/// </summary>
	/// <value>
	///   The email address.
	/// </value>
	public string EmailAddress { get; set; } = string.Empty;
}