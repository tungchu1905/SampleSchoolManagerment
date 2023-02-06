using Authorization_RoleTest.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Validation;
using SampleSchoolManagermentV1.Services.Interfaces;

namespace SampleSchoolManagermentV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class MarksController : ControllerBase
    {
        private readonly IMarkService _markService;
        public MarksController(IMarkService markService)
        {
            _markService = markService;
        }
        /// <summary>
        /// Hiển thị danh sách điểm (chưa hiển thị tên học sinh)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestPaginate requestPaginate) {
            var listMark = await _markService.GetMarkPagedList(requestPaginate);
            return Ok(listMark);
        }
        /// <summary>
        /// Lấy chi tiết điểm theo id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Detail")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var result = await _markService.GetDetailMark(id);
            return Ok(result);
        }

        /// <summary>
        /// Nhập điểm cho học sinh 
        /// </summary>
        /// <param name="createMarkDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMark(CreateMarkDTO createMarkDTO)
        {
            var result = await _markService.CraeteMark(createMarkDTO);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật điểm cho học sinh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateMarkDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateMarkDTO updateMarkDTO)
        {
            var result = await _markService.UpdateMark(id, updateMarkDTO);
            return Ok(result);
        }

        /// <summary>
        /// Xóa điểm cho học sinh
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _markService.DeleteMark(id);
            return Ok(result);
        }

        /// <summary>
        /// Hiển thị điểm trung bình của một học sinh trong một học kì
        /// </summary>
        /// <param name="id"></param>
        /// <param name="semester"></param>
        /// <returns></returns>
        [HttpGet("getAvgOneStudentMark")]
        public async Task<IActionResult> GetAverageMarkOfOneStudent(int studentId, int semester)
        {
            var result = await _markService.GetAverageMarkOfOneStudent(studentId, semester);
            return Ok(result);
        }

        /// <summary>
        /// Lấy điểm trung bình 1 học kì của một môn trong một lớp học
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="classId"></param>
        /// <param name="semester"></param>
        /// <returns></returns>
        [HttpGet("AvgMarkClass")]
        public async Task<IActionResult> GetAvgSubjectMarkOfOneClass(string subjectName, int classId, int semester)
        {
            var result = await _markService.GetAverageMarkOnASubjectInOneClass(subjectName, classId, semester);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách điểm học sinh theo loại điểm, khối và học kì
        /// </summary>
        /// <param name="typeOfMark"></param>
        /// <returns></returns>
        [HttpGet("GetListType")]
        public async Task<IActionResult> GetDetailList(string typeOfMark, int grade, int semester)
        {
            var result = await _markService.GetMarkByTypeOfMark(typeOfMark, grade, semester);
            return Ok(result);
        }

        /// <summary>
        /// Lấy điểm trung bình của một môn của một học sinh trong một học kì
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="subjectName"></param>
        /// <param name="semester"></param>
        /// <returns></returns>
        [HttpGet("GetAvgStudentMarkOfOneSubject")]
        public async Task<IActionResult> GetAverageStudentMark(int studentId, string subjectName, int semester)
        {
            var result = await _markService.GetAverageMarkOfSubjectOneStudentInSemester(studentId, subjectName, semester);
            return Ok(result);
        }
    }
}
