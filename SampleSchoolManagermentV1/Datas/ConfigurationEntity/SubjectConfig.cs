using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Datas.ConfigurationEntity
{
    public class SubjectConfig : IEntityTypeConfiguration<InforSubject>
    {
        public void Configure(EntityTypeBuilder<InforSubject> builder)
        {
            builder.HasData(
                  new InforSubject() { Id = 1, SubjectName = "Toan", Grade = 1, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 2, SubjectName = "Toan", Grade = 1, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 3, SubjectName = "Van", Grade = 1, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 4, SubjectName = "Van", Grade = 1, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 5, SubjectName = "Anh", Grade = 1, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 6, SubjectName = "Anh", Grade = 1, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 7, SubjectName = "Hoa", Grade = 1, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 8, SubjectName = "Hoa", Grade = 1, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 9, SubjectName = "Li", Grade = 1, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 10, SubjectName = "Li", Grade = 1, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 11, SubjectName = "Sinh", Grade = 1, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 12, SubjectName = "Sinh", Grade = 1, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 13, SubjectName = "GDCD", Grade = 1, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 14, SubjectName = "GDCD", Grade = 1, Semester = 2, SlotInWeek = 5 },

             // lop 2
             new InforSubject() { Id = 15, SubjectName = "Toan", Grade = 2, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 16, SubjectName = "Toan", Grade = 2, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 17, SubjectName = "Van", Grade = 2, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 18, SubjectName = "Van", Grade = 2, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 19, SubjectName = "Anh", Grade = 2, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 20, SubjectName = "Anh", Grade = 2, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 21, SubjectName = "Hoa", Grade = 2, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 22, SubjectName = "Hoa", Grade = 2, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 23, SubjectName = "Li", Grade = 2, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 24, SubjectName = "Li", Grade = 2, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 25, SubjectName = "Sinh", Grade = 2, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 26, SubjectName = "Sinh", Grade = 2, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 27, SubjectName = "GDCD", Grade = 2, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 28, SubjectName = "GDCD", Grade = 2, Semester = 2, SlotInWeek = 5 },

             // lop 3
             new InforSubject() { Id = 29, SubjectName = "Toan", Grade = 3, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 30, SubjectName = "Toan", Grade = 3, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 31, SubjectName = "Van", Grade = 3, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 32, SubjectName = "Van", Grade = 3, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 33, SubjectName = "Anh", Grade = 3, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 34, SubjectName = "Anh", Grade = 3, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 35, SubjectName = "Hoa", Grade = 3, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 36, SubjectName = "Hoa", Grade = 3, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 37, SubjectName = "Li", Grade = 3, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 38, SubjectName = "Li", Grade = 3, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 39, SubjectName = "Sinh", Grade = 3, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 40, SubjectName = "Sinh", Grade = 3, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 41, SubjectName = "GDCD", Grade = 3, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 42, SubjectName = "GDCD", Grade = 3, Semester = 2, SlotInWeek = 5 },

             // lop 4
             new InforSubject() { Id = 43, SubjectName = "Toan", Grade = 4, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 44, SubjectName = "Toan", Grade = 4, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 45, SubjectName = "Van", Grade = 4, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 46, SubjectName = "Van", Grade = 4, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 47, SubjectName = "Anh", Grade = 4, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 48, SubjectName = "Anh", Grade = 4, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 49, SubjectName = "Hoa", Grade = 4, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 50, SubjectName = "Hoa", Grade = 4, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 51, SubjectName = "Li", Grade = 4, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 52, SubjectName = "Li", Grade = 4, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 53, SubjectName = "Sinh", Grade = 4, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 54, SubjectName = "Sinh", Grade = 4, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 55, SubjectName = "GDCD", Grade = 4, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 56, SubjectName = "GDCD", Grade = 4, Semester = 2, SlotInWeek = 5 },

             // lop 5
             new InforSubject() { Id = 57, SubjectName = "Toan", Grade = 5, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 58, SubjectName = "Toan", Grade = 5, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 59, SubjectName = "Van", Grade = 5, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 60, SubjectName = "Van", Grade = 5, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 61, SubjectName = "Anh", Grade = 5, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 62, SubjectName = "Anh", Grade = 5, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 63, SubjectName = "Hoa", Grade = 5, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 64, SubjectName = "Hoa", Grade = 5, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 65, SubjectName = "Li", Grade = 5, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 66, SubjectName = "Li", Grade = 5, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 67, SubjectName = "Sinh", Grade = 5, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 68, SubjectName = "Sinh", Grade = 5, Semester = 2, SlotInWeek = 5 },
             new InforSubject() { Id = 69, SubjectName = "GDCD", Grade = 5, Semester = 1, SlotInWeek = 5 },
             new InforSubject() { Id = 70, SubjectName = "GDCD", Grade = 5, Semester = 2, SlotInWeek = 5 }

                );
        }
    }
}
