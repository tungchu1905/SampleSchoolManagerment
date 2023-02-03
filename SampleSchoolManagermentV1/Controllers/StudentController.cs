using Authorization_RoleTest.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Model;
using SampleSchoolManagermentV1.Services.Interfaces;

namespace SampleSchoolManagermentV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.User)]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        /// <summary>
        /// Lấy tất cả danh sách học sinh (chưa hiển thị thông tin class và điểm)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllStudent([FromQuery] RequestPaginate requestPaginate )
        {
           var listStudent = await _studentService.GetStudentPagedList(requestPaginate);
            return Ok(listStudent);
        }
        /// <summary>
        /// Lấy thông tin của một học sinh (chưa hiển thị thông tin class và điểm)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DetailStudent")]
        public async Task<IActionResult> GetDetailStudent(int id)
        {
            var result = await _studentService.GetDetailStudent(id);
            return Ok(result);
        }

        /// <summary>
        /// Tạo một học sinh mới
        /// </summary>
        /// <param name="createStudentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewStudent(CreateStudentDTO createStudentDTO)
        {
            var result = await _studentService.CraeteStudent(createStudentDTO);
            return Ok(result);
        }

        /// <summary>
        /// Xóa một học sinh
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật, chỉnh sửa học sinh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateStudentDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDTO updateStudentDTO)
        {
            var result = await _studentService.UpdateStudent(id, updateStudentDTO);
            return Ok(result);
        }
    }
}
