using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Model;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services
{
    public class MarkService : IMarkService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MarkService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InforMark>> GetAllMark()
        {
            var listMark = await _unitOfWork.MarkRepository.GetAll();
            return (List<InforMark>)listMark;
        }

        public async Task<InforMark> GetDetailMark(int id)
        {
            if (id > 0)
            {
                var detail = await _unitOfWork.MarkRepository.Get(id);
                if (detail != null)
                {
                    return detail;
                }
                return null;
            }
            return null;
        }
        public async Task<bool> CraeteMark(CreateMarkDTO createMarkDTO)
        {
            if (createMarkDTO != null)
            {
                var newMark = _mapper.Map<InforMark>(createMarkDTO);
                await _unitOfWork.MarkRepository.Add(newMark);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMark(int id)
        {
            if (id > 0)
            {
                var result = await _unitOfWork.MarkRepository.Get(id);
                if (result != null)
                {
                    _unitOfWork.MarkRepository.Delete(result);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            return false;
        }
        public async Task<bool> UpdateMark(int id, UpdateMarkDTO updateMarkDTO)
        {
            if (id > 0)
            {
                var result = await _unitOfWork.MarkRepository.Get(id);
                if (result != null)
                {
                    _mapper.Map(updateMarkDTO, result);
                    _unitOfWork.MarkRepository.Update(result);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IPagedList<InforMark>> GetMarkPagedList(RequestPaginate requestPaginate)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetAverageMarkOfOneStudent(int id, int semester)
        {
            
            var students = await _unitOfWork.StudentRepository.GetAll();
            var marks = await _unitOfWork.MarkRepository.GetAll();
            var subjects = await _unitOfWork.SubjectRepository.GetAll();
            var result = (from s in students
                          join m in marks
                      on s.Id equals m.StudentId
                          join subj in subjects
                          on m.SubjectId equals subj.Id
                          where s.Id == id && subj.Semester == semester
                          select new
                          {
                              studentname = s.StudentName,
                              SubjectName = subj.SubjectName,
                              average = marks.Average(x => x.Mark)

                          }).FirstOrDefault();
            //.Average(x => x.Mark);
            if (result != null)
            {
                return result;
            }
            else
                return null;

        }

        public async Task<object> GetAverageMarkOnASubjectInOneClass(string subjectName, int classId, int semester)
        {
            var students = await _unitOfWork.StudentRepository.GetAll();
            var marks = await _unitOfWork.MarkRepository.GetAll();
            var subjects = await _unitOfWork.SubjectRepository.GetAll();
            var result = (from s in students
                          join m in marks
                          on s.Id equals m.StudentId
                          join subj in subjects
                          on m.SubjectId equals subj.Id
                          where subj.SubjectName == subjectName && s.ClassId == classId && subj.Semester == semester
                          select new
                          {
                              SubjectName = subj.SubjectName,
                              average = marks.Average(x => x.Mark)
                          }).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }
    }
}
