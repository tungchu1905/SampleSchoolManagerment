using DinkToPdf;
using DinkToPdf.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.Datas;
using SampleSchoolManagermentV1.Services.Interfaces;
using SampleSchoolManagermentV1.Validation;
using System.Text;

namespace SampleSchoolManagermentV1.Controllers.File
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private SchoolContext _context { get; }
        private readonly ITimeTableService _timeTableService;
        private readonly IConverter _converter;
        public FilesController(SchoolContext schoolContext, ITimeTableService timeTableService, IConverter converter)
        {
            _context = schoolContext;
            _timeTableService = timeTableService;
            _converter = converter;
        }
        

        /// <summary>
        ///  Export data thời khóa biểu sang file pdf (chưa xong)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreatePDF()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"D:\TimetableReport.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = FileService.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "style.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" },
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            return Ok("Successfully created the PDF document");
        }
    }

}
