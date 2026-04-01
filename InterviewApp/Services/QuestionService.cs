using InterviewApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using InterviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewApp.Services
{
    public class QuestionService
    {
        private readonly AppDbContext _context;

        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddQuestionAsync(Models.Question question)
        {
            var new_question = new Models.Question
            {
                QuestionText = question.QuestionText,
                QuestionDetails = question.QuestionDetails,
                CategoryId = question.CategoryId
            };
        }


        public async Task RemoveQuestionAsync(Models.Question question)
        {
            var question_to_remove = _context.Questions.Find(question.Id);
            if (question_to_remove != null)
            {
                _context.Questions.Remove(question_to_remove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateQuestionAsync(Models.Question question)
        {
            var question_to_update = _context.Questions.Find(question.Id);
            if (question_to_update != null)
            {
                question_to_update.QuestionText = question.QuestionText;
                question_to_update.QuestionDetails = question.QuestionDetails;
                question_to_update.CategoryId = question.CategoryId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions
                            .Include(q => q.Category)
                            .FirstOrDefaultAsync(q => q.Id == id);
        }
        
        public async Task<List<Question>> GetQuestionsByCategoryIdAsync(int categoryId)
        {
            return await _context.Questions
                            .Where(q => q.CategoryId == categoryId)
                            .ToListAsync();
        } 
    }

}