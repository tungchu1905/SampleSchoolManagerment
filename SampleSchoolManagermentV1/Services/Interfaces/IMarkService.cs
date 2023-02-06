using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface IMarkService
    {
        Task<List<InforMark>> GetAllMark();
        Task<object> GetDetailMark(int id);
        Task<bool> CraeteMark(CreateMarkDTO createMarkDTO);
        Task<bool> UpdateMark(int id, UpdateMarkDTO updateMarkDTO);
        Task<bool> DeleteMark(int id);

        //////// 
        Task<object> GetMarkPagedList(RequestPaginate requestPaginate);

        Task<object> GetAverageMarkOfOneStudent(int id, int semester);
        Task<object> GetAverageMarkOnASubjectInOneClass(string subjectName, int classId, int semester);

        Task<object> GetMarkByTypeOfMark(string typeOfMark, int grade, int semester);
        Task<object> GetAverageMarkOfSubjectOneStudentInSemester(int studentId, string subjectName, int semester);
    }
}
