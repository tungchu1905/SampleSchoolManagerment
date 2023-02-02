
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SampleSchoolManagermentV1.Datas.ConfigurationEntity;
using SampleSchoolManagermentV1.Entities;

namespace SampleSchoolManagermentV1.Datas
{
    public class SchoolContext :IdentityDbContext<IdentityUser>
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<InforClass> inforClasses { get; set; }
        public DbSet<InforMark>   inforMarks { get; set; }
        public DbSet<InforStudent> inforStudents { get; set; }
        public DbSet<InforSubject> inforSubjects { get; set; }
        public DbSet<InforTimeTable> inforTimeTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.InvalidIncludePathError));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClassConfig());
            builder.ApplyConfiguration(new SubjectConfig());
            builder.ApplyConfiguration(new StudentConfig());
            builder.ApplyConfiguration(new MarkConfig());
            builder.ApplyConfiguration(new TimetableConfig());
        }
    }
}
