using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<InforSubject>> GetAllSubject();
        Task<object> GetInforSubject(int id);
        Task<bool> CreateSubject(CreateSubjectDTO createSubjectDTO);
        Task<bool> UpdateSubject(int id, UpdateSubjectDTO updateSubjectDTO);
        Task<bool> DeleteSubject(int id);
        //////// 
        Task<IPagedList<InforSubject>> GetSubjetcPagedList(RequestPaginate requestPaginate);
    }
}
