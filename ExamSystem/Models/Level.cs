using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class Level
    {
        public Level()
        {
            QuestionDetails = new HashSet<QuestionDetail>();
        }

        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<QuestionDetail> QuestionDetails { get; set; }
    }
}
