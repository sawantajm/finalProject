using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class AddQuestion
    {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Correctanswer { get; set; }
        public string StudentResponse { get; set; }
    }
}
