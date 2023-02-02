namespace SampleSchoolManagermentV1.DTO
{
    public class StudentDTO : CreateStudentDTO
    {
        public int Id { get; set; }
        public virtual ICollection<MarkDTO> MarkDTOs { get; set; } = new List<MarkDTO>();
    }
    public class CreateStudentDTO
    {
        public string StudentName { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set;}
        public int? ClassId { get; set; }
    }
    public class UpdateStudentDTO : CreateStudentDTO
    {

    }
}
