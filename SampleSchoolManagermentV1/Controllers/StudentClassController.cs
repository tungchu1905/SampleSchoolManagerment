using Authorization_RoleTest.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Services.Interfaces;
using SampleSchoolManagermentV1.Validation;
using SampleSchoolManagermentV1.Validation.FluentValidation;

namespace SampleSchoolManagermentV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = UserRoles.Admin)]
    public class StudentClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public StudentClassController(IClassService classService)
        {
            _classService = classService;
        }
        /// <summary>
        /// Lấy tất cả danh sách lớp học
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestPaginate requestPaginate)
        {
                var classList = await _classService.GetClassPagedList(requestPaginate);
                return Ok(classList);
        }

        /// <summary>
        /// Lấy chi tiết lớp học (bao gồm tên gv chủ nhiệm và số học sinh trong lớp)
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
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateNewClass(CreateClassDTO classDTO)
        {
            ClassValidator validationRules = new ClassValidator();
            var validationResult = validationRules.Validate(classDTO);
            if (!validationResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors);
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
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateClass(int id, UpdateClassDTO updateClassDTO)
        {
            ClassValidator validationRules = new ClassValidator();
            var validationResult = validationRules.Validate(updateClassDTO);
            if (!validationResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors);
            }
            await _classService.UpdateClass(id, updateClassDTO);
            return Ok(updateClassDTO);
        }

    }
}
