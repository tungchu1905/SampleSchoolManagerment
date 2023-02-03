namespace SampleSchoolManagermentV1.DTO
{
    public class MarkDTO : CreateMarkDTO
    {
        public int Id { get; set; }
        public virtual StudentDTO StudentDTO { get; set; } = new StudentDTO();

    }
    public class CreateMarkDTO
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string typeOfMark { get; set; }
        public int Mark { get; set; }
    }
    public class UpdateMarkDTO: CreateMarkDTO
    {

    }
}
