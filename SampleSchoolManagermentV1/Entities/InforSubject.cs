using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleSchoolManagermentV1.Entities
{
    [Table("Subject")]
    public class InforSubject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string SubjectName { get; set; }
        [Required]
        [Range(1,12)]
        public int Grade { get; set; }
        [Required]
        [Range(1,2)]
        public int Semester { get; set; }
        [Required]
        [Range(1,10)]
        public int SlotInWeek { get; set; }

        public virtual ICollection<InforMark> InformationMarks { get; set; } = default!;
        public virtual ICollection<InforTimeTable> InforTimeTables { get; set; } = default!;
    }
}
