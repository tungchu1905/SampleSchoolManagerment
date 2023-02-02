using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleSchoolManagermentV1.Entities
{
    [Table("StudentMark")]
    public class InforMark
    {
        
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(InformationStudent))]
        public int StudentId { get; set; }
        public virtual InforStudent InformationStudent { get; set; }


        [ForeignKey(nameof(InformationSubject))]
        public int SubjectId { get; set; }
        public virtual InforSubject InformationSubject { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string typeOfMark { get; set; }
        [Required]
        [Range(1,10)]
        public float Mark { get; set; }
    }
}
