using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface ITimeTableService
    {
        Task<List<InforTimeTable>> GetAllTimeTable();
        Task<object> GetInforTimeTable(int id);
        Task<bool> CreateTimeTable(CreateTimeTableDTO createTimeTableDTO);
        Task<bool> UpdateTimeTable(int id, UpdateTimeTableDTO updateTimeTableDTO);
        Task<bool> DeleteTimeTable(int id);

        Task<IPagedList<InforTimeTable>> GetTimetablePagedList(RequestPaginate requestPaginate);
    }
}
