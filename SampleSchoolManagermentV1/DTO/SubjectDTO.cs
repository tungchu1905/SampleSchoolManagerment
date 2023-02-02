namespace SampleSchoolManagermentV1.DTO
{
    public class SubjectDTO : CreateSubjectDTO
    {
        public int Id { get; set; }
        public virtual ICollection<MarkDTO> MarkDTOs { get; set; } = new List<MarkDTO>();
        public virtual ICollection<TimeTableDTO> TimeTableDTOs { get; set; } = new List<TimeTableDTO>();
    }
    public class CreateSubjectDTO
    {
        public string SubjectName { get; set; }
        public int Grade { get; set; }
        public int Semester { get; set; }
        public int SlotInWeek { get; set; }
    }
    public class UpdateSubjectDTO : CreateSubjectDTO
    {

    }
}
