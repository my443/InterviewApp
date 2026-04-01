using InterviewApp.Data;
using InterviewApp.Models;
using InterviewApp.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TestingInterviewApp
{
    public class CategoryServiceTests
    {
        // Helper to create a clean context for every test
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique name per test
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task AddCategoryAsync_Should_Add_Category_To_Database()
        {
            // Arrange
            var context = GetDbContext();
            var service = new CategoryService(context);
            var category = new Category { Name = "DotNet", CategoryDetails = "C# Questions" };

            // Act
            await service.AddCategoryAsync(category);

            // Assert
            var savedCategory = await context.Categories.FirstOrDefaultAsync();
            Assert.NotNull(savedCategory);
            Assert.Equal("DotNet", savedCategory.Name);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_Should_Return_With_Questions()
        {
            // Arrange
            var context = GetDbContext();
            var category = new Category { Name = "HR", CategoryDetails = "Behavioral" };
            category.Questions = new List<Question> { new Question { QuestionText = "Why us?", QuestionDetails="" } };

            context.Categories.Add(category);
            await context.SaveChangesAsync(); // Seed the data

            var service = new CategoryService(context);

            // Act
            var result = await service.GetCategoryByIdAsync(category.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Questions); // Verifies the .Include() worked!
        }
    }
}
