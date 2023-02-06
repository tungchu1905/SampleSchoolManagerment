using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface IStudentService 
    {
        Task<List<InforStudent>> GetAllStudent();
        Task<object> GetDetailStudent(int id);
        Task<bool> CraeteStudent(CreateStudentDTO createClassDTO);
        Task<bool> UpdateStudent(int id, UpdateStudentDTO updateClassDTO);
        Task<bool> DeleteStudent(int id);

        //////// 
        Task<object> GetStudentPagedList(RequestPaginate requestPaginate);
    }
}
