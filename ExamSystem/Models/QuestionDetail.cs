using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class QuestionDetail
    {
        public int QuestionId { get; set; }
        public int? QuestionNumber { get; set; }
        public int? FileId { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Correctanswers { get; set; }
        public int? SubjectId { get; set; }
        public int? LevelId { get; set; }
        public string StudentResponse { get; set; }

        public virtual Filename File { get; set; }
        public virtual Level Level { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
