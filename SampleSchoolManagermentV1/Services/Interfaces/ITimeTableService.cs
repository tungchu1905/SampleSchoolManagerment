﻿using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface ITimeTableService
    {
        Task<List<InforTimeTable>> GetAllTimeTable();
        Task<InforTimeTable> GetInforTimeTable(int id);
        Task<bool> CreateTimeTable(CreateTimeTableDTO createTimeTableDTO);
        Task<bool> UpdateTimeTable(int id, UpdateTimeTableDTO updateTimeTableDTO);
        Task<bool> DeleteTimeTable(int id);
    }
}