using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Services.Interfaces
{
    public interface IFileExcelService
    {
        Task<List<InforTimeTable>> CreateTimeTable(int classId);
    }
}
