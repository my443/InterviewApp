using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using InterviewApp.Models;

namespace InterviewApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<InterviewTemplate> InterviewTemplates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
