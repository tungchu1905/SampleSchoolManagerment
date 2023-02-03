using System.ComponentModel.DataAnnotations.Schema;

namespace SampleSchoolManagermentV1.DTO
{
    public class StudentDTO : CreateStudentDTO
    {
        public int Id { get; set; }
        public virtual ClassDTO ClassDTO { get; set; } = new ClassDTO();
        public virtual ICollection<MarkDTO> MarkDTOs { get; set; } = new List<MarkDTO>();
    }
    public class CreateStudentDTO
    {
        [Column("StudentName")]
        public string StudentName { get; set; }
        [Column("Gender")]
        public bool Gender { get; set; }
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("FatherName")]
        public string? FatherName { get; set; }
        [Column("MotherName")]
        public string? MotherName { get; set;}
        [Column("ClassId")]
        public int? ClassId { get; set; }
    }
    public class UpdateStudentDTO : CreateStudentDTO
    {

    }
}
