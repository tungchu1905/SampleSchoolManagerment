using SampleSchoolManagermentV1.Datas;
using SampleSchoolManagermentV1.Repository.Repositories.Interfaces;

namespace SampleSchoolManagermentV1.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _schoolContext;
        public IClassRepository ClassRepository { get; }
        public IMarkRepository MarkRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public ITimeTableRepository TimeTableRepository { get; }


        public UnitOfWork(SchoolContext schoolContext, 
            IClassRepository classRepository, 
            IStudentRepository studentRepository, 
            ISubjectRepository subjectRepository,
            IMarkRepository markRepository, ITimeTableRepository timeTableRepository)
        {
            _schoolContext = schoolContext;
            ClassRepository = classRepository;
            StudentRepository = studentRepository;
            SubjectRepository = subjectRepository;
            MarkRepository = markRepository;
            TimeTableRepository = timeTableRepository;
        }

        public int Complete() 
        {
            return _schoolContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing)
        {
            if(disposing)
            {
                _schoolContext.Dispose();
            }
        }
    }
}
