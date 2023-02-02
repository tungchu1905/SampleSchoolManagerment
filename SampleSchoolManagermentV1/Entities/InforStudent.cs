using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleSchoolManagermentV1.Entities
{
    public class InforStudent
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string? FatherName { get; set; }

        public string? MotherName { get; set; }

        [ForeignKey(nameof(InformationClass))]
        public int ClassId { get; set; }
        public virtual InforClass InformationClass { get; set; }

        public virtual ICollection<InforMark> InformationMarks { get; set; } = default!;
    }
}
