using ExamSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamSystem
{
    public class MarkObtainedcal
    {
        public int count = 0;





        public int MarksObtain(int count)
        {
            QuestionDetail question = new QuestionDetail();

            if (question.SubjectId == 1 && question.LevelId == 1)
            {

                for (var QuestionNumber = 0; QuestionNumber < question.QuestionNumber; QuestionNumber++)
                {
                    if (question.Correctanswers[QuestionNumber] == question.StudentResponse[QuestionNumber])
                    {
                        count = count + 1;
                    }
                    else
                    {
                        count = count;
                    }


                }

            }
            return count;
        }
    }
}
