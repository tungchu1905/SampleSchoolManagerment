namespace SampleSchoolManagermentV1.Entities
{
    public class InforClass
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int Grade { get; set; }
        public string TeacherName { get; set; }
        public virtual ICollection<InforStudent> Students { get; set; } = default!;


    }
}
