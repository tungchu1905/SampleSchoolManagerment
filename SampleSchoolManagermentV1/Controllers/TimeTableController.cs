using Authorization_RoleTest.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Model;
using SampleSchoolManagermentV1.Services;
using SampleSchoolManagermentV1.Services.Interfaces;

namespace SampleSchoolManagermentV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class TimeTableController : ControllerBase
    {
        private readonly ITimeTableService _timeTableService;
        public TimeTableController(ITimeTableService timeTableService)
        {
            _timeTableService = timeTableService;
        }
        /// <summary>
        /// Hiển thị danh sách thời khóa biểu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestPaginate requestPaginate)
        {
            var listMark = await _timeTableService.GetTimetablePagedList(requestPaginate);
            return Ok(listMark);
        }
        /// <summary>
        /// Lấy chi tiết thời khóa biểu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Detail")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var result = await _timeTableService.GetInforTimeTable(id);
            return Ok(result);
        }

        /// <summary>
        /// Nhập môn học vào thời khóa biểu
        /// </summary>
        /// <param name="createTimeTableDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTimetable(CreateTimeTableDTO createTimeTableDTO)
        {
            var result = await _timeTableService.CreateTimeTable(createTimeTableDTO);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật thời khóa biểu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTimeTableDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateTimeTableDTO updateTimeTableDTO)
        {
            var result = await _timeTableService.UpdateTimeTable(id, updateTimeTableDTO);
            return Ok(result);
        }

        /// <summary>
        /// Xóa môn học trong thời khóa biểu cho học sinh
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _timeTableService.DeleteTimeTable(id);
            return Ok(result);
        }
    }
}
