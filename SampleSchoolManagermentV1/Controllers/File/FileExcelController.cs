using Authorization_RoleTest.Validation;
using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;
using System.Data;

namespace SampleSchoolManagermentV1.Controllers.File
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileExcelController : ControllerBase
    {
        private readonly IFileExcelService _handleFileService;
        public FileExcelController(IFileExcelService handleFileService)
        {
            _handleFileService = handleFileService;
        }

        /// <summary>
        /// Lưu thông tin thời khóa biểu của 1 lớp vào excel 
        /// </summary>
        /// <returns></returns>
        [HttpGet("DowloadFileExcelTimeTable")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> FileStreamResultExcelSalary(int classId)
        {
            var result = await _handleFileService.CreateTimeTable(classId);


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("TimeTable");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Day";
                worksheet.Cell(currentRow, 2).Value = "Slot";
                worksheet.Cell(currentRow, 3).Value = "Subject Name";
                worksheet.Cell(currentRow, 4).Value = "Grade";
                worksheet.Cell(currentRow, 5).Value = "Class Name";
                worksheet.Cell(currentRow, 6).Value = "Teacher Name";
                foreach (var item in result)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Day;
                    worksheet.Cell(currentRow, 2).Value = item.slot;
                    worksheet.Cell(currentRow, 3).Value = item.InformationSubject.SubjectName;
                    worksheet.Cell(currentRow, 4).Value = item.InformationSubject.Grade;
                    worksheet.Cell(currentRow, 5).Value = item.InformationClass.ClassName;
                    worksheet.Cell(currentRow, 6).Value = item.InformationClass.TeacherName;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "TimeTable.xlsx");
                }
            }
        }
    }
}
