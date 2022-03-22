using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class Subject
    {
        public Subject()
        {
            QuestionDetails = new HashSet<QuestionDetail>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<QuestionDetail> QuestionDetails { get; set; }
    }
}
