using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class ReportDetail
    {
        public int? UserId { get; set; }
        public int? LevelId { get; set; }
        public int? MarksObtained { get; set; }
        public int? SubjectId { get; set; }

        public virtual Level Level { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Registration User { get; set; }
    }
}
