using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class Filename
    {
        public Filename()
        {
            QuestionDetails = new HashSet<QuestionDetail>();
        }

        public int FileId { get; set; }
        public string FileName1 { get; set; }

        public virtual ICollection<QuestionDetail> QuestionDetails { get; set; }
    }
}
