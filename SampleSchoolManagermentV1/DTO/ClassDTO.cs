namespace SampleSchoolManagermentV1.DTO
{
    public class ClassDTO : CreateClassDTO
    {
        public int Id { get; set; }
        public virtual ICollection<StudentDTO> StudentDTOs { get; set; } = new List<StudentDTO>();
    }

    public class CreateClassDTO
    {
        public string ClassName { get; set; }
        public int Grade { get; set; }
        public string TeacherName { get; set; }
    }
    public class UpdateClassDTO : CreateClassDTO
    {

    }
}
