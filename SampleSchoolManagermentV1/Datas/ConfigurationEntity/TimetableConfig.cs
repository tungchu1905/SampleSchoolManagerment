using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Datas.ConfigurationEntity
{
    public class TimetableConfig : IEntityTypeConfiguration<InforTimeTable>
    {
        public void Configure(EntityTypeBuilder<InforTimeTable> builder)
        {
            builder.HasData(
                 // Thu 2 lop 1A
                 new InforTimeTable() { Id = 1, Day = "Thu 2", SubjectId = 1, slot = 2, Classid = 1 },
                 new InforTimeTable() { Id = 2, Day = "Thu 2", SubjectId = 3, slot = 3, Classid = 1 },
                 new InforTimeTable() { Id = 3, Day = "Thu 2", SubjectId = 5, slot = 4, Classid = 1 },
                 new InforTimeTable() { Id = 4, Day = "Thu 2", SubjectId = 7, slot = 6, Classid = 1 },
                 new InforTimeTable() { Id = 5, Day = "Thu 2", SubjectId = 9, slot = 7, Classid = 1 },
                 new InforTimeTable() { Id = 6, Day = "Thu 2", SubjectId = 11, slot = 8, Classid = 1 },
                 // Thu 3  lop 1A
                 new InforTimeTable() { Id = 7, Day = "Thu 3", SubjectId = 13, slot = 1, Classid = 1 },
                 new InforTimeTable() { Id = 8, Day = "Thu 3", SubjectId = 1, slot = 3, Classid = 1 },
                 new InforTimeTable() { Id = 9, Day = "Thu 3", SubjectId = 5, slot = 5, Classid = 1 },
                 new InforTimeTable() { Id = 10, Day = "Thu 3", SubjectId = 7, slot = 7, Classid = 1 },
                 new InforTimeTable() { Id = 11, Day = "Thu 3", SubjectId = 9, slot = 9, Classid = 1 },

                 // Thu 4  lop 1A
                 new InforTimeTable() { Id = 12, Day = "Thu 4", SubjectId = 5, slot = 1, Classid = 1 },
                 new InforTimeTable() { Id = 13, Day = "Thu 4", SubjectId = 3, slot = 2, Classid = 1 },
                 new InforTimeTable() { Id = 14, Day = "Thu 4", SubjectId = 7, slot = 4, Classid = 1 },
                 new InforTimeTable() { Id = 15, Day = "Thu 4", SubjectId = 13, slot = 6, Classid = 1 },
                 new InforTimeTable() { Id = 16, Day = "Thu 4", SubjectId = 1, slot = 8, Classid = 1 },

                 // Thu 5  lop 1A
                 new InforTimeTable() { Id = 17, Day = "Thu 5", SubjectId = 1, slot = 2, Classid = 1 },
                 new InforTimeTable() { Id = 18, Day = "Thu 5", SubjectId = 7, slot = 4, Classid = 1 },
                 new InforTimeTable() { Id = 19, Day = "Thu 5", SubjectId = 13, slot = 6, Classid = 1 },
                 new InforTimeTable() { Id = 20, Day = "Thu 5", SubjectId = 9, slot = 8, Classid = 1 },

                  // Thu 6  lop 1A
                 new InforTimeTable() { Id = 21, Day = "Thu 6", SubjectId = 3, slot = 1, Classid = 1 },
                 new InforTimeTable() { Id = 22, Day = "Thu 6", SubjectId = 5, slot = 4, Classid = 1 },
                 new InforTimeTable() { Id = 23, Day = "Thu 6", SubjectId = 9, slot = 6, Classid = 1 },
                 new InforTimeTable() { Id = 24, Day = "Thu 6", SubjectId = 7, slot = 7, Classid = 1 }
                 );
        }
    }
}
