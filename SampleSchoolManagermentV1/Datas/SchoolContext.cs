
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

        public DbSet<InforClass> informationClass { get; set; }
        public DbSet<InforMark>   informationMarks { get; set; }
        public DbSet<InforStudent> informatuonStudents { get; set; }
        public DbSet<InforSubject> informationSubjects { get; set; }
        public DbSet<InforTimeTable> informationTimeTables { get; set; }

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
