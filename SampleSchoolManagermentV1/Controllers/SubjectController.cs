﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Services.Interfaces;

namespace SampleSchoolManagermentV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        /// <summary>
        /// Lấy danh sách môn học (chưa hiển thị thông tin điểm và thời khóa biểu)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllSubject()
        {
            var listSubject = await _subjectService.GetAllSubject();
            return Ok(listSubject);
        }
        /// <summary>
        /// Lấy chi tiêt 1 môn học (chưa hiển thị thông tin điểm và thời khóa biểu)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DetailSubject")]
        public async Task<IActionResult> GetDetailSubject(int id)
        {
            var detailSubject = await _subjectService.GetInforSubject(id);
            return Ok(detailSubject);
        }
        /// <summary>
        /// Tạo môn học mới 
        /// </summary>
        /// <param name="createSubjectDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewSubject(CreateSubjectDTO createSubjectDTO)
        {
            var result = await _subjectService.CreateSubject(createSubjectDTO);
            return Ok(result);
        }
        /// <summary>
        /// Chỉnh sửa môn học
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSubjectDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSubject(int id, UpdateSubjectDTO updateSubjectDTO)
        {
            var result = await _subjectService.UpdateSubject(id, updateSubjectDTO);
            return Ok(result);
        }
        /// <summary>
        /// Xóa một môn học
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _subjectService.DeleteSubject(id);
            return Ok(result);
        }
    }
}