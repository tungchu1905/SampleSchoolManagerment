using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CraeteStudent(CreateStudentDTO createClassDTO)
        {
            if (createClassDTO == null)
            {
                return false;
            }
            var newStudent = _mapper.Map<InforStudent>(createClassDTO);
            await _unitOfWork.StudentRepository.Add(newStudent);
            var result = (_unitOfWork.Complete() > 0 ? true : false);
            return result;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            if (id > 0)
            {
                var deleteStudent = await _unitOfWork.StudentRepository.Get(id);
                if (deleteStudent == null)
                {
                    return false;
                }
                else
                {
                     _unitOfWork.StudentRepository.Delete(deleteStudent);
                    _unitOfWork.Complete();
                    return true;
                }
            }
            return false;
        }

        public async Task<List<InforStudent>> GetAllStudent()
        {
            var listStudent = await _unitOfWork.StudentRepository.GetAll();
            return (List<InforStudent>)listStudent;
        }

        public async Task<object> GetDetailStudent(int id)
        {
            List<string> include = new List<string> { "InformationMarks", "InformationClass" };
            var studentList = await _unitOfWork.StudentRepository.GetAllAsync(include);
            if (studentList.Any())
            {
                var result = studentList.Where(x => x.Id == id)
               .Select(x => new
               {
                   x.Id,
                   x.StudentName,
                   x.Gender,
                   x.DateOfBirth,
                   x.Address,
                   x.InformationClass.ClassName, x.InformationClass.Grade, x.InformationClass.TeacherName,
                   Marks = x.InformationMarks.Select(x => new { x.typeOfMark, x.Mark, x.InformationSubject })
               }).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<object> GetStudentPagedList(RequestPaginate requestPaginate)
        {
            List<string> include = new List<string> { "InformationMarks", "InformationClass", "InformationSubject" };
            var studentList = await _unitOfWork.StudentRepository.GetPagedList(requestPaginate, include);
            if (studentList.Any())
            {
                var result = studentList
               .Select(x => new
               {
                   x.Id,
                   x.StudentName,
                   x.Gender,
                   x.DateOfBirth,
                   x.Address,
                   x.InformationClass.ClassName,
                   x.InformationClass.Grade,
                   x.InformationClass.TeacherName,
                  Marks =  x.InformationMarks.Select(x=> new {x.typeOfMark, x.Mark, x.InformationSubject})


               }).ToList();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdateStudent(int id, UpdateStudentDTO updateClassDTO)
        {
            if(id > 0)
            {
                var updateClass = await _unitOfWork.StudentRepository.Get(id);
                _mapper.Map(updateClassDTO, updateClass);
                _unitOfWork.StudentRepository.Update(updateClass);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }
    }
}
