using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleSchoolManagermentV1.Entities
{
    [Table("TimeTable")]
    public class InforTimeTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar")]
        [StringLength(100)]
        public string Day { get; set; }

        [ForeignKey("InformationSubject")]
        public int SubjectId { get; set; }
        public virtual InforSubject InformationSubject { get; set; }

        [Range(1, 10)]
        public int slot { get; set; }
    }
}
