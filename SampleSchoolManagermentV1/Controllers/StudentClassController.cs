using Authorization_RoleTest.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Model;
using SampleSchoolManagermentV1.Model.FluentValidation;
using SampleSchoolManagermentV1.Services.Interfaces;

namespace SampleSchoolManagermentV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class StudentClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public StudentClassController(IClassService classService)
        {
            _classService = classService;
        }
        /// <summary>
        /// Lấy tất cả danh sách lớp học (chưa hiển thị học sinh)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //try
            //{
                var classList = await _classService.GetAllClass();
                return Ok(classList);
            //}
            //catch (Exception)
            //{
            //    return BadRequest();
            //}
        }

        /// <summary>
        /// Lấy chi tiết lớp học (chưa bao gồm số học sinh trong lớp)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DetailClass")]
        public async Task<IActionResult> GetDetailClass(int id)
        {
            var result = await _classService.GetDetailClass(id);
            return Ok(result);
        }

        /// <summary>
        /// Tạo một lớp học mới
        /// </summary>
        /// <param name="classDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewClass(ClassDTO classDTO)
        {
            ClassValidator validationRules = new ClassValidator();
            var validationResult = validationRules.Validate(classDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest();
            }
            await _classService.CraeteClass(classDTO);
            return Ok(classDTO);    
        }

        /// <summary>
        /// Xóa một lớp học 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var result = await _classService.DeleteClass(id);
            return Ok(result);
        }

        /// <summary>
        /// Chỉnh sửa một lớp học 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateClassDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateClass(int id, UpdateClassDTO updateClassDTO)
        {
            ClassValidator validationRules = new ClassValidator();
            var validationResult = validationRules.Validate(updateClassDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest();
            }
            await _classService.UpdateClass(id, updateClassDTO);
            return Ok(updateClassDTO);
        }

    }
}
