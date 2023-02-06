using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface IClassService
    {
        Task<List<InforClass>> GetAllClass();
        Task<object> GetDetailClass(int id);
        Task<bool> CraeteClass(CreateClassDTO createClassDTO);
        Task<bool> UpdateClass(int id, UpdateClassDTO updateClassDTO);
        Task<bool> DeleteClass(int id);

        //////// 
        Task<IPagedList<InforClass>> GetClassPagedList(RequestPaginate requestPaginate);
    }
}
