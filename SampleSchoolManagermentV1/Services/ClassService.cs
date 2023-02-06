using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ClassService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // read
        public async Task<List<InforClass>> GetAllClass()
        {
            var classes = await _unitOfWork.ClassRepository.GetAll();
            return (List<InforClass>)classes;
        }

        public async Task<object> GetClassPagedList(RequestPaginate requestPaginate)
        {
            List<string> include = new List<string> { "InformationStudents" };
            var classList = await _unitOfWork.ClassRepository.GetPagedList(requestPaginate, include);
            if (classList.Any())
            {
                var result = classList
               .Select(x => new
               {
                   x.ClassName,
                   x.Grade,
                   x.TeacherName,
                   InforStudent = x.InformationStudents.Select(x => new { x.StudentName, x.Gender, x.DateOfBirth, x.Address })
               }).ToList();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            return null;
        }

        // create
        public async Task<bool> CraeteClass(CreateClassDTO createClassDTO)
        {
            if (createClassDTO == null)
            {
                return false;
            }
            var newClass = _mapper.Map<InforClass>(createClassDTO);
            await _unitOfWork.ClassRepository.Add(newClass);
            var result = (_unitOfWork.Complete() > 0) ? true : false;

            return result;
        }

        //delete
        public async Task<bool> DeleteClass(int id)
        {
            if (id > 0)
            {
                var classRoom = await _unitOfWork.ClassRepository.Get(id);
                _unitOfWork.ClassRepository.Delete(classRoom);
                var result = _unitOfWork.Complete();
                if (result > 0)
                {
                    return true;
                }
                else return false;

            }
            return false;
        }


        // detail
        public async Task<object> GetDetailClass(int id)
        {
            List<string> include = new List<string> { "InformationStudents" };
            var classes = await _unitOfWork.ClassRepository.GetAllAsync(include);
            if (classes.Any())
            {
                var result = classes.Where(x => x.Id == id)
               .Select(x => new
               {
                   x.ClassName,
                   x.Grade,
                   x.TeacherName,
                   InforStudent =  x.InformationStudents.Select(x=> new { x.StudentName , x.Gender,x.DateOfBirth, x.Address})
               }).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            return null;
        }

        // update
        public async Task<bool> UpdateClass(int id, UpdateClassDTO updateClassDTO)
        {
            if (id > 0)
            {
                var updateClass = await _unitOfWork.ClassRepository.Get(id);
                _mapper.Map(updateClassDTO, updateClass);
                _unitOfWork.ClassRepository.Update(updateClass);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }
    }
}
