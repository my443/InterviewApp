using InterviewApp.Data;
using InterviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewApp.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            var new_category = new Models.Category
            {
                Name = category.Name,
                CategoryDetails = category.CategoryDetails
            };

            _context.Categories.Add(new_category);
            _context.SaveChanges();
        }

        public async Task RemoveCategoryAsync(Category category)
        {
            var category_to_remove = _context.Categories.Find(category.Id);

            if (category_to_remove != null)
            {
                _context.Categories.Remove(category_to_remove);
                _context.SaveChanges();
            }
        }


        public async Task UpdateCategoryAsync(Category category)
        {
            var category_to_update = _context.Categories.Find(category.Id);
            if (category_to_update != null)
            {
                category_to_update.Name = category.Name;
                category_to_update.CategoryDetails = category.CategoryDetails;
                _context.SaveChanges();
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                    .Include(c => c.Questions) 
                    .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories
                    .Include(c => c.Questions)
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();
        }
    }
}
