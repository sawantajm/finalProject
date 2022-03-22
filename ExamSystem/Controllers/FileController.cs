using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamSystem.Models;
using System.IO;
using System.Data;
using ExcelDataReader;

namespace ExamSystem.Controllers
{
    [Route("api/fileupload")]
    [ApiController]
    public class FileController : ControllerBase
    { private readonly OnlineExamContext db;
        public FileController(OnlineExamContext context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult ExcelUpload(int fileid, IFormCollection formdata)
        {

            var file = HttpContext.Request.Form.Files[20];
            try
            {
                using (db)
                {


                    Stream stream = file.OpenReadStream();

                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    IExcelDataReader reader = null;

                    if (file.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (file.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    }


                    DataSet excelRecords = reader.AsDataSet();
                    reader.Close();

                    var finalRecords = excelRecords.Tables[0];
                    for (int i = 1; i < finalRecords.Rows.Count; i++)
                    {
                        QuestionDetail tbq = new QuestionDetail();
                        tbq.FileId = fileid;
                        tbq.Question = finalRecords.Rows[i][0].ToString();
                        tbq.Option1 = finalRecords.Rows[i][1].ToString();
                        tbq.Option2 = finalRecords.Rows[i][2].ToString();
                        tbq.Option3 = finalRecords.Rows[i][3].ToString();
                        tbq.Option4 = finalRecords.Rows[i][4].ToString();
                        tbq.Correctanswers = finalRecords.Rows[i][5].ToString();

                        db.QuestionDetails.Add(tbq);
                    }

                    int output = db.SaveChanges();
                    if (output > 0)
                    {
                        //isSaveSuccess = true;
                        return Ok();
                    }
                    else
                    {
                        //isSaveSuccess = false;
                        return BadRequest(new { message = "Invalid file extension" });
                    }
                }







            }catch(Exception e)
            {
                return Ok("file no uploaded");
            }
            


            }
    }
}
