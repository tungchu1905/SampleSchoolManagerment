using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Datas.ConfigurationEntity
{
    public class StudentConfig : IEntityTypeConfiguration<InforStudent>
    {
        public void Configure(EntityTypeBuilder<InforStudent> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(x => x.Id);


            //config 
            builder.Property(p => p.StudentName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("StudentName")
                .HasColumnType("nvarchar");

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("Gender");
            builder.Property(p => p.DateOfBirth)
                .IsRequired()
                .HasColumnName("DateOfBirth")
                .HasColumnType("date")
                ;
            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar")
                .HasColumnName("Address");

            builder.Property(p => p.FatherName)
                .HasColumnName("FatherName")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(p => p.MotherName)
                .HasColumnName("MotherName")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            // seed data
            builder.HasData(
                  new InforStudent() { Id = 1, StudentName = "Nguyen Khanh Toan", Gender = true, DateOfBirth = new DateTime(2015, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 1 },
              new InforStudent() { Id = 2, StudentName = "Nguyen Ngoc Long", Gender = false, DateOfBirth = new DateTime(2015, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 1 },
              new InforStudent() { Id = 3, StudentName = "Chu Khanh Toan", Gender = true, DateOfBirth = new DateTime(2015, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 2 },
              new InforStudent() { Id = 4, StudentName = "Hoang Van Long", Gender = true, DateOfBirth = new DateTime(2015, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 2 },
              new InforStudent() { Id = 5, StudentName = "Pham Thanh Xuan", Gender = false, DateOfBirth = new DateTime(2014, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 3 },
              new InforStudent() { Id = 6, StudentName = "Vu Duc Khanh", Gender = true, DateOfBirth = new DateTime(2014, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 3 },
              new InforStudent() { Id = 7, StudentName = "Chuong Thi Khanh Toan", Gender = false, DateOfBirth = new DateTime(2014, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 4 },
              new InforStudent() { Id = 8, StudentName = "Nguyen Thanh Long", Gender = true, DateOfBirth = new DateTime(2014, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 4 },
              new InforStudent() { Id = 9, StudentName = "Do Thi Huong", Gender = false, DateOfBirth = new DateTime(2013, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 5 },
              new InforStudent() { Id = 10, StudentName = "Truong Dang Hieu", Gender = true, DateOfBirth = new DateTime(2013, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 5 },
              new InforStudent() { Id = 11, StudentName = "Truong Quoc Sinh", Gender = true, DateOfBirth = new DateTime(2013, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 6 },
              new InforStudent() { Id = 12, StudentName = "Nguyen Thu Huong", Gender = false, DateOfBirth = new DateTime(2013, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 6 },
              new InforStudent() { Id = 13, StudentName = "Do Thi Mai", Gender = false, DateOfBirth = new DateTime(2013, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 6 },
              new InforStudent() { Id = 14, StudentName = "Nguyen Khanh Mai", Gender = true, DateOfBirth = new DateTime(2015, 12, 31), Address = "Ha Noi", FatherName = "", MotherName = "", ClassId = 1 }

                );
        }
    }
}
