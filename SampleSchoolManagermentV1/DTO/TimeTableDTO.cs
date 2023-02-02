namespace SampleSchoolManagermentV1.DTO
{
    public class TimeTableDTO : CreateTimeTableDTO
    {
        public int Id { get; set; }

    }
    public class CreateTimeTableDTO
    {
        public string Day { get; set; }
        public int? SubjectId { get; set; }
        public int slot { get; set; }
    }
    public class UpdateTimeTableDTO : CreateTimeTableDTO
    {

    }
}
