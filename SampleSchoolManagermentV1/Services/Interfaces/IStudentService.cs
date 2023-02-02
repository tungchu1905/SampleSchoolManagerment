﻿using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Model;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface IStudentService 
    {
        Task<List<InforStudent>> GetAllStudent();
        Task<InforStudent> GetDetailStudent(int id);
        Task<bool> CraeteStudent(CreateStudentDTO createClassDTO);
        Task<bool> UpdateStudent(int id, UpdateStudentDTO updateClassDTO);
        Task<bool> DeleteStudent(int id);

        //////// 
        Task<IPagedList<InforStudent>> GetStudentPagedList(RequestPaginate requestPaginate);
    }
}