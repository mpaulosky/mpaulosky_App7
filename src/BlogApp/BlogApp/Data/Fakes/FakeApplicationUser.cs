// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeApplicationUser.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using BlogApp.Data.Models;

namespace BlogApp.Data.Fakes;

public class FakeApplicationUser
{
	/// <summary>
	///   Gets a new ApplicationUser.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <returns>ApplicationUser</returns>
	public static Models.ApplicationUser GetNewUser(bool keepId = false)
	{
		UserModel? user = GenerateFakeUserModel.GenerateFake().Generate();

		var appUser = new Models.ApplicationUser { Id = user.Id, UserName = user.DisplayName, Email = user.EmailAddress };

		if (!keepId)
		{
			appUser.Id = string.Empty;
		}

		return appUser;
	}

	/// <summary>
	///   Gets a list of ApplicationUsers.
	/// </summary>
	/// <param name="numberOfUsers">The number of users.</param>
	/// <returns>A List of ApplicationUsers</returns>
	public static List<Models.ApplicationUser> GetUsers(int numberOfUsers)
	{
		List<UserModel>? users = GenerateFakeUserModel.GenerateFake().Generate(numberOfUsers);
		List<Models.ApplicationUser> appUsers = [];
		appUsers.AddRange(users.Select(user =>
			new Models.ApplicationUser { Id = user.Id, UserName = user.DisplayName, Email = user.EmailAddress }));

		return appUsers;
	}
}