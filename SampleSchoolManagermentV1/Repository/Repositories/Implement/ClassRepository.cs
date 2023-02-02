using SampleSchoolManagermentV1.Datas;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Repository.General;
using SampleSchoolManagermentV1.Repository.Repositories.Interfaces;

namespace SampleSchoolManagermentV1.Repository.Repositories.Implement
{
    public class ClassRepository : GenericRepository<InforClass>, IClassRepository
    {
        public ClassRepository(SchoolContext schoolContext) : base(schoolContext) { }
    }
}
