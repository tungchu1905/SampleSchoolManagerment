using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Datas.ConfigurationEntity
{
    public class ClassConfig : IEntityTypeConfiguration<InforClass>
    {
        public void Configure(EntityTypeBuilder<InforClass> builder)
        {
            builder.ToTable("InforClass");
            builder.HasKey(x => x.Id);

            // config column
            builder.Property(c => c.ClassName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ClassName")
                .HasColumnOrder(1)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Grade)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnType("integer")
                .HasColumnName("Grade");

            builder.Property(c=>c.TeacherName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar")
                .HasColumnName("TeacherName");

            // Seed data
            builder.HasData(
                  new InforClass() { Id = 1, ClassName = "1A", Grade = 1, TeacherName = "Nguyen Thi Hanh" },
                new InforClass() { Id = 2, ClassName = "1B", Grade = 1, TeacherName = "Nguyen Thi Hoa" },
                new InforClass() { Id = 3, ClassName = "2A", Grade = 2, TeacherName = "Nguyen Van Thanh" },
                new InforClass() { Id = 4, ClassName = "2B", Grade = 2, TeacherName = "Chu Thi Hanh" },
                new InforClass() { Id = 5, ClassName = "3A", Grade = 3, TeacherName = "Nguyen Thi Thuy" },
                new InforClass() { Id = 6, ClassName = "3B", Grade = 3, TeacherName = "Chu Thi Thuy" },
                new InforClass() { Id = 7, ClassName = "4A", Grade = 4, TeacherName = "Hoang Thi Tham" },
                new InforClass() { Id = 8, ClassName = "4B", Grade = 4, TeacherName = "Vuong Thi Minh Hanh" },
                new InforClass() { Id = 9, ClassName = "5A", Grade = 5, TeacherName = "Hoang Thi Hoa" },
                new InforClass() { Id = 10, ClassName = "5B", Grade = 5, TeacherName = "Pham Thi Chuc" },

                new InforClass() { Id = 11, ClassName = "1C", Grade = 1, TeacherName = "Hoang Thi Tham" },
                new InforClass() { Id = 12, ClassName = "1D", Grade = 1, TeacherName = "Vuong Thi Minh Hanh" },
                new InforClass() { Id = 13, ClassName = "2C", Grade = 2, TeacherName = "Hoang Thi Hoa" },
                new InforClass() { Id = 14, ClassName = "2D", Grade = 2, TeacherName = "Pham Thi Chuc" }


                );

        }
    }
}
