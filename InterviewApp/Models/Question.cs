using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InterviewApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionDetails { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
