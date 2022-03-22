using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class ExamDetail
    {
        public TimeSpan? Duration { get; set; }
        public int? LevelId { get; set; }
        public int? Cutoff { get; set; }
        public int? ExamId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Level Level { get; set; }
    }
}
