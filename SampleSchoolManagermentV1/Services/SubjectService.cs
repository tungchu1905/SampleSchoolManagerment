using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<InforSubject>> GetAllSubject()
        {
            var listStudent = await _unitOfWork.SubjectRepository.GetAll();
            return (List<InforSubject>)listStudent;
        }

        public async Task<object> GetInforSubject(int id)
        {
            List<string> include = new List<string> { "InformationMarks", "InforTimeTables" };
            var subjectList = await _unitOfWork.SubjectRepository.GetAllAsync(include);
            if (subjectList.Any())
            {
                var result = subjectList.Where(x => x.Id == id)
               .Select(x => new
               {
                   x.SubjectName,
                   x.Grade,
                   x.Semester,
                  inforTimeTable =  x.InforTimeTables
                  .Select(x=> new { x.Day, x.slot, x.Classid, x.InformationClass })
                  
               }).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            return null;
        }


        public async Task<bool> CreateSubject(CreateSubjectDTO createSubjectDTO)
        {
            if (createSubjectDTO == null)
            {
                return false;
            }
            var newSubject = _mapper.Map<InforSubject>(createSubjectDTO);
            await _unitOfWork.SubjectRepository.Add(newSubject);
            _unitOfWork.Complete();
            return true;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            if (id > 0)
            {
                var deleteSubject = await _unitOfWork.SubjectRepository.Get(id);
                _unitOfWork.SubjectRepository.Delete(deleteSubject);

                _unitOfWork.Complete();
                return true;
            }
            return false;

        }


        public async Task<bool> UpdateSubject(int id, UpdateSubjectDTO updateSubjectDTO)
        {
            if (id > 0)
            {
                var updateSubject = await _unitOfWork.SubjectRepository.Get(id);
                _mapper.Map(updateSubjectDTO, updateSubject);
                _unitOfWork.SubjectRepository.Update(updateSubject);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }

        public async Task<object> GetSubjetcPagedList(RequestPaginate requestPaginate)
        {
            List<string> include = new List<string> { "InformationMarks", "InforTimeTables" };
            var subjectList = await _unitOfWork.SubjectRepository.GetPagedList(requestPaginate, include);
            if (subjectList.Any())
            {
                var result = subjectList
               .Select(x => new
               {
                   x.SubjectName,
                   x.Grade,
                   x.Semester,
                   inforTimeTable = x.InforTimeTables
                  .Select(x => new { x.Day, x.slot, x.Classid, x.InformationClass })

               }).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            return null;
        }
    }
}
