namespace SampleSchoolManagermentV1.DTO
{
    public class TimeTableDTO : CreateTimeTableDTO
    {
        public int Id { get; set; }
        public virtual SubjectDTO SubjectDTO { get; set; } = new SubjectDTO();
        

    }
    public class CreateTimeTableDTO
    {
        public string Day { get; set; }
        public int? SubjectId { get; set; }
        public int slot { get; set; }
        public int Classid { get; set; }
    }
    public class UpdateTimeTableDTO : CreateTimeTableDTO
    {

    }
}
