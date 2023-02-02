using SampleSchoolManagermentV1.Repository.Repositories.Interfaces;

namespace SampleSchoolManagermentV1.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClassRepository ClassRepository { get; }
        IMarkRepository MarkRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ITimeTableRepository TimeTableRepository { get; }
        int Complete();
    }
}
