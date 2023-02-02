using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Datas.ConfigurationEntity
{
    public class MarkConfig : IEntityTypeConfiguration<InforMark>
    {
        public void Configure(EntityTypeBuilder<InforMark> builder)
        {
            builder.HasData(
                new InforMark() { Id = 1, StudentId = 1, SubjectId = 1, typeOfMark = "15 phut", Mark = 4 },
             new InforMark() { Id = 2, StudentId = 2, SubjectId = 1, typeOfMark = "15 phut", Mark = 5 },
             new InforMark() { Id = 3, StudentId = 3, SubjectId = 1, typeOfMark = "15 phut", Mark = 7 },
             new InforMark() { Id = 4, StudentId = 4, SubjectId = 1, typeOfMark = "15 phut", Mark = 6 },
             new InforMark() { Id = 5, StudentId = 5, SubjectId = 1, typeOfMark = "15 phut", Mark = 8 },
             new InforMark() { Id = 6, StudentId = 6, SubjectId = 1, typeOfMark = "15 phut", Mark = 9 },

            //1 tiet
             new InforMark() { Id = 7, StudentId = 1, SubjectId = 1, typeOfMark = "1 Tiet", Mark = 8 },
             new InforMark() { Id = 8, StudentId = 2, SubjectId = 1, typeOfMark = "1 Tiet", Mark = 5 },
             new InforMark() { Id = 9, StudentId = 3, SubjectId = 1, typeOfMark = "1 Tiet", Mark = 7 },
             new InforMark() { Id = 10, StudentId = 4, SubjectId = 1, typeOfMark = "1 Tiet", Mark = 4 },
             new InforMark() { Id = 11, StudentId = 5, SubjectId = 1, typeOfMark = "1 Tiet", Mark = 6 },
             new InforMark() { Id = 12, StudentId = 6, SubjectId = 1, typeOfMark = "1 Tiet", Mark = 9 },

            // giua ki
             new InforMark() { Id = 13, StudentId = 1, SubjectId = 1, typeOfMark = "Giua ki", Mark = 8 },
             new InforMark() { Id = 14, StudentId = 2, SubjectId = 1, typeOfMark = "Giua ki", Mark = 4 },
             new InforMark() { Id = 15, StudentId = 3, SubjectId = 1, typeOfMark = "Giua ki", Mark = 6 },
             new InforMark() { Id = 16, StudentId = 4, SubjectId = 1, typeOfMark = "Giua ki", Mark = 4 },
             new InforMark() { Id = 17, StudentId = 5, SubjectId = 1, typeOfMark = "Giua ki", Mark = 5 },
             new InforMark() { Id = 18, StudentId = 6, SubjectId = 1, typeOfMark = "Giua ki", Mark = 7 },

            // cuoi ki
             new InforMark() { Id = 19, StudentId = 1, SubjectId = 1, typeOfMark = "Cuoi ki", Mark = 7 },
             new InforMark() { Id = 20, StudentId = 2, SubjectId = 1, typeOfMark = "Cuoi ki", Mark = 4 },
             new InforMark() { Id = 21, StudentId = 3, SubjectId = 1, typeOfMark = "Cuoi ki", Mark = 5 },
             new InforMark() { Id = 22, StudentId = 4, SubjectId = 1, typeOfMark = "Cuoi ki", Mark = 7 },
             new InforMark() { Id = 23, StudentId = 5, SubjectId = 1, typeOfMark = "Cuoi ki", Mark = 8 },
             new InforMark() { Id = 24, StudentId = 6, SubjectId = 1, typeOfMark = "Cuoi ki", Mark = 9 },

              // diem cua 1 hs
              new InforMark() { Id = 25, StudentId = 1, SubjectId = 2, typeOfMark = "15 phut", Mark = 9 },
              new InforMark() { Id = 26, StudentId = 1, SubjectId = 2, typeOfMark = "1 tiet", Mark = 9 },
              new InforMark() { Id = 27, StudentId = 1, SubjectId = 2, typeOfMark = "Giua ki", Mark = 9 },
              new InforMark() { Id = 28, StudentId = 1, SubjectId = 2, typeOfMark = "Cuoi ki", Mark = 9 },
              // VAN
              new InforMark() { Id = 29, StudentId = 1, SubjectId = 3, typeOfMark = "15 phut", Mark = 6 },
              new InforMark() { Id = 30, StudentId = 1, SubjectId = 3, typeOfMark = "1 tiet", Mark = 5 },
              new InforMark() { Id = 31, StudentId = 1, SubjectId = 3, typeOfMark = "Giua ki", Mark = 6 },
              new InforMark() { Id = 32, StudentId = 1, SubjectId = 3, typeOfMark = "Cuoi ki", Mark = 7 }

                );
        }
    }
}
