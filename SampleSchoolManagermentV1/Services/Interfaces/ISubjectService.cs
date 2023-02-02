﻿using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<InforSubject>> GetAllSubject();
        Task<InforSubject> GetInforSubject(int id);
        Task<bool> CreateSubject(CreateSubjectDTO createSubjectDTO);
        Task<bool> UpdateSubject(int id, UpdateSubjectDTO updateSubjectDTO);
        Task<bool> DeleteSubject(int id);
    }
}