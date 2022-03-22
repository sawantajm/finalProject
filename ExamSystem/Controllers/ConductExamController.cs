using ExamSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductExamController : ControllerBase
    {
        private readonly OnlineExamContext db;


        public ConductExamController(OnlineExamContext context)
        {
            db = context;
        }

        public object Question { get; private set; }

        [HttpGet]
        [Route("Level1")]
        public IActionResult conductExam()
        {

            try
            {
                //for Level1
                var que = from q in db.QuestionDetails
                          join l in db.Levels on q.LevelId equals l.LevelId
                          join s in db.Subjects on q.SubjectId equals s.SubjectId
                          where q.LevelId == 1 && q.SubjectId == 1

                          select new
                          {
                              QuestionNo = q.QuestionNumber,
                              Question = q.Question,
                              Option1 = q.Option1,
                              Option2 = q.Option2,
                              Option3 = q.Option3,
                              Option4 = q.Option4,
                              Level = l.LevelName
                          };

                return Ok(que);

            }
            catch (Exception e)
            {
                return Ok("Exception Occured");
            }
        }

        [HttpGet]
        [Route("Level2")]
        public IActionResult conductExam1()
        {

            try
            { //for Level1
                var que = from q in db.QuestionDetails
                          join l in db.Levels on q.LevelId equals l.LevelId
                          join s in db.Subjects on q.SubjectId equals s.SubjectId
                          where q.LevelId == 2 && q.SubjectId == 1

                          select new
                          {
                              QuestionNo = q.QuestionNumber,
                              Question = q.Question,
                              Option1 = q.Option1,
                              Option2 = q.Option2,
                              Option3 = q.Option3,
                              Option4 = q.Option4,
                              Level = l.LevelName
                          };

                return Ok(que);

            }
            catch (Exception e)
            {
                return Ok("Exception Occured");
            }
        }


        [HttpGet]
        [Route("Level3")]
        public IActionResult conductExam2()
        {

            try
            {
                var que = from q in db.QuestionDetails
                          join l in db.Levels on q.LevelId equals l.LevelId
                          join s in db.Subjects on q.SubjectId equals s.SubjectId
                          where q.LevelId == 3 && q.SubjectId == 1

                          select new
                          {
                              QuestionNo = q.QuestionNumber,
                              Question = q.Question,
                              Option1 = q.Option1,
                              Option2 = q.Option2,
                              Option3 = q.Option3,
                              Option4 = q.Option4,
                              Level = l.LevelName
                          };

                return Ok(que);

            }
            catch (Exception e)
            {
                return Ok("");
            }
        }
        [HttpPut]

        public IActionResult saveResponces(string student_response, int? question_id, QuestionDetail questionDetail)
        {

            var respo = db.QuestionDetails.FirstOrDefault(x => x.QuestionId == question_id);
            try
            {
                if (respo != null)
                {
                    respo.StudentResponse = student_response;
                    db.SaveChanges();
                    return Ok("Response Save");
                }
                else
                {
                    return Ok("response not save");
                }
            }
            catch (Exception e)
            {
                return Ok("Try Again");
            }
        }

    }
}
