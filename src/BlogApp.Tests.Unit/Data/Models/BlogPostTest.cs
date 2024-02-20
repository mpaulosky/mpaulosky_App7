// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostTest.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_App6
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

namespace BlogApp.Tests.Unit.Data.Models;

[TestSubject(typeof(BlogPost))]
[ExcludeFromCodeCoverage]
public class BlogPostTest
{
	[Fact]
	public void BlogPost_With_BlogPost_Test()
	{
		// Arrange
		BlogPost? expected = FakeBlogPost.GetNewBlogPost(true);

		// Act
		BlogPost result = new(expected);

		// Assert
		result.Id.Should().BeEquivalentTo(expected!.Id);
		result.ObjectIdentifier.Should().Be(expected.ObjectIdentifier);
		result.Url.Should().Be(expected.Url);
		result.Title.Should().Be(expected.Title);
		result.Content.Should().Be(expected.Content);
		result.Created.Should().Be(expected.Created);
		result.Updated.Should().Be(expected.Updated);
		result.Author.Should().BeEquivalentTo(expected.Author);
		result.Description.Should().Be(expected.Description);
		result.Image.Should().Be(expected.Image);
		result.IsPublished.Should().Be(expected.IsPublished);
		result.IsArchived.Should().Be(expected.IsArchived);
		result.ArchivedBy.Should().BeEquivalentTo(expected.ArchivedBy);
	}
}