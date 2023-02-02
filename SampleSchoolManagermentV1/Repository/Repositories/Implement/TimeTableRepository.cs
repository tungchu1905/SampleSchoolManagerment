using SampleSchoolManagermentV1.Datas;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Repository.General;
using SampleSchoolManagermentV1.Repository.Repositories.Interfaces;

namespace SampleSchoolManagermentV1.Repository.Repositories.Implement
{
    public class TimeTableRepository : GenericRepository<InforTimeTable>, ITimeTableRepository
    {
        public TimeTableRepository(SchoolContext schoolContext) : base(schoolContext) { }
    }
}
