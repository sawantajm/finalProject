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
    public class ReportDetailsController : ControllerBase
    {
        private readonly OnlineExamContext db;
        public int count;
        public ReportDetailsController(OnlineExamContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Result(int userid)

        {
            try
            {
                var report = db.ReportDetails.FirstOrDefault(x => x.UserId == userid);

                MarkObtainedcal marks = new MarkObtainedcal();
                var val = marks.MarksObtain(count);
              


                if (report != null)
                {
                    report.MarksObtained = count;
                    db.SaveChanges();
                    return Ok("marks save");

                }
                else
                {
                    return Ok("not save");
                }



            }
            catch (Exception e)
            {
                return Ok("Try Again");

            }







        }
    }
}
