using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Datas.ConfigurationEntity
{
    public class TimetableConfig : IEntityTypeConfiguration<InforTimeTable>
    {
        public void Configure(EntityTypeBuilder<InforTimeTable> builder)
        {
            
        }
    }
}
