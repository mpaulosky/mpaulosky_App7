// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostDtoTest.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

using NSubstitute;

namespace BlogApp.Tests.Unit.Data.Models;

[TestSubject(typeof(BlogPostDto))]
[ExcludeFromCodeCoverage]
public class BlogPostDtoTest
{
	[Fact]
	public void TestBlogPostDtoCreation()
	{
		var blogPostDto = new BlogPostDto();
		Assert.NotNull(blogPostDto);
	}

	[Fact]
	public void TestDateTimeNotNull()
	{
		var dateTimeWrapper = Substitute.For<IDateTimeWrapper>();
		dateTimeWrapper.Now.Returns(new DateTime(2024, 01, 01, 10, 00, 00));
		var blogPostDto = new BlogPostDto { Created = dateTimeWrapper.Now };
		blogPostDto.Created.Should().Be(dateTimeWrapper.Now);
	}

	[Fact]
	public void TestIsPublishedDefaultValue()
	{
		var blogPostDto = new BlogPostDto();
		blogPostDto.IsPublished.Should().BeFalse();
	}

	[Fact]
	public void TestFieldsAfterInitialization()
	{
		var blogPostDto = new BlogPostDto();
		blogPostDto.Image.Should().BeEmpty();
		blogPostDto.IsArchived.Should().BeFalse();
	}

	[Fact]
	public void TestAuthorAfterInitialization()
	{
		var blogPostDto = new BlogPostDto();
		blogPostDto.Author.Should().NotBeNull();
	}
	
	[Fact]
	public void BlogPostDto_With_BlogPostDto_Test()
	{
		// Arrange
		BlogPostDto expected = FakeBlogPostDto.GetNewBlogPostDto();

		// Act
		BlogPostDto result = new(expected);

		// Assert
		result.Url.Should().Be(expected.Url);
		result.Title.Should().Be(expected.Title);
		result.Content.Should().Be(expected.Content);
		result.Created.Should().Be(expected.Created);
		result.Author.Should().BeEquivalentTo(expected.Author);
		result.Description.Should().Be(expected.Description);
		result.Image.Should().Be(expected.Image);
		result.IsPublished.Should().Be(expected.IsPublished);
		result.IsArchived.Should().Be(expected.IsArchived);
	}
}