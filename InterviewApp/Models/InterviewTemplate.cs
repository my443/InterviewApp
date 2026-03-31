using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewApp.Models
{
    public class InterviewTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string Description { get; set; }        
        public List<Question> InterviewQuestions { get; set; }  
    }
}
