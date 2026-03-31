using InterviewApp.Data;
using InterviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewApp.Services
{
    public class InterviewTemplateService
    {
        private readonly AppDbContext _context;

        public InterviewTemplateService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddInterviewTemplateAsync(InterviewTemplate template)
        {
            var new_template = new InterviewTemplate
            {
                Name = template.Name,
                Description = template.Description,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                InterviewQuestions = template.InterviewQuestions

            };
            _context.InterviewTemplates.Add(new_template);
            _context.SaveChanges();
        }

        public async Task RemoveInterviewTemplateAsync(InterviewTemplate template)
        {
            var template_to_remove = _context.InterviewTemplates.Find(template.Id);
            if (template_to_remove != null)
            {
                _context.InterviewTemplates.Remove(template_to_remove);
                _context.SaveChanges();
            }
        }

        public async Task UpdateInterviewTemplateAsync(InterviewTemplate template)
        {
            var template_to_update = _context.InterviewTemplates.Find(template.Id);
            if (template_to_update != null)
            {
                template_to_update.Name = template.Name;
                template_to_update.Description = template.Description;
                template_to_update.InterviewQuestions = template.InterviewQuestions;
                _context.SaveChanges();
            }
        }

        public async Task<List<InterviewTemplate>> GetAllInterviewTemplatesAsync()
        {
            return await _context.InterviewTemplates.ToListAsync();
        }

        public async Task<InterviewTemplate> GetInterviewTemplateByIdAsync(int id)
        {
            return await _context.InterviewTemplates
                            .Include(t => t.InterviewQuestions) 
                            .FirstOrDefaultAsync(t => t.Id == id);
        }

    }
}
