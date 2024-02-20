// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BasicUser.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using System.ComponentModel.DataAnnotations;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApp.Data.Models;

/// <summary>
///   BasicUser class
/// </summary>
[Serializable]
public class BasicUser
{
	/// <summary>
	///   Initializes a new instance of the <see cref="BasicUser" /> class.
	/// </summary>
	public BasicUser()
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="BasicUser" /> class.
	/// </summary>
	/// <param name="id">The Users Id.</param>
	/// <param name="objectIdentifier"></param>
	/// <param name="userName">The Users Name.</param>
	/// <param name="emailAddress">The Users Email Address</param>
	public BasicUser(string id, string objectIdentifier, string userName, string emailAddress) : this()
	{
		Id = id;
		ObjectIdentifier = objectIdentifier;
		UserName = userName;
		EmailAddress = emailAddress;
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="BasicUser" /> class.
	/// </summary>
	/// <param name="user">The user.</param>
	public BasicUser(ApplicationUser user)
	{
		Id = user.Id;
		ObjectIdentifier = user.Id;
		EmailAddress = user.Email;
		UserName = user.UserName;
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="BasicUser" /> class.
	/// </summary>
	/// <param name="user">The user.</param>
	public BasicUser(UserModel user)
	{
		Id = user.Id;
		ObjectIdentifier = user.ObjectIdentifier;
		EmailAddress = user.EmailAddress;
		UserName = user.DisplayName;
	}

	/// <summary>
	///   Gets the identifier.
	/// </summary>
	/// <value>
	///   The identifier.
	/// </value>
	[BsonId]
	[BsonElement("_id")]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? Id { get; init; } = string.Empty;

	/// <summary>
	///   Gets or sets the object identifier.
	/// </summary>
	/// <value>
	///   The object identifier.
	/// </value>
	[BsonElement("object_identifier")]
	public string ObjectIdentifier { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the UserName.
	/// </summary>
	/// <value>
	///   The UserName.
	/// </value>
	[BsonElement("user_name")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(100)]
	public string? UserName { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the email address.
	/// </summary>
	/// <value>
	///   The email address.
	/// </value>
	[BsonElement("email_address")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(150)]
	public string? EmailAddress { get; set; } = string.Empty;
}