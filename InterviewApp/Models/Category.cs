using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryDetails { get; set; }

        public List<Question> Questions { get; set; }
    }
}
