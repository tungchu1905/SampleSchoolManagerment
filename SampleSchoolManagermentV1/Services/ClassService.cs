using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;
using X.PagedList;
using SampleSchoolManagermentV1.Controllers;

namespace SampleSchoolManagermentV1.Services
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ClassService> _logger;
        public ClassService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ClassService> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // read
        public async Task<List<InforClass>> GetAllClass()
        {
            _logger.LogInformation("Studednt Class executing ...");
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
                   x.Id,
                   x.ClassName,
                   x.Grade,
                   x.TeacherName,
                   InforStudent = x.InformationStudents.Select(x => new { x.StudentName, x.Gender, x.DateOfBirth, x.Address })
               }).ToList();
                if (result != null)
                {
                    _logger.LogInformation("Student Class show information ");
                    return result;
                }
                _logger.LogError("Student Class show nothing ");
                return null;
            }
            _logger.LogError("Student Class show nothing ");
            return null;
        }

        // create
        public async Task<bool> CraeteClass(CreateClassDTO createClassDTO)
        {
            if (createClassDTO == null)
            {
                _logger.LogError($"Cannot create new Class class name =\"{createClassDTO.ClassName}\".");
                return false;
            }
            var newClass = _mapper.Map<InforClass>(createClassDTO);
            await _unitOfWork.ClassRepository.Add(newClass);
            var result = (_unitOfWork.Complete() > 0) ? true : false;
            _logger.LogInformation($"Create new Class success for class : \"{createClassDTO.ClassName}\"");
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
                    _logger.LogInformation($"Delete ClassName : \"{classRoom.ClassName} \" with id: \"{classRoom.Id}\" successfully ");
                    return true;
                }

                else
                {
                    _logger.LogInformation($"Cannot Delete ClassName : \"{classRoom.ClassName} \" with id: \"{classRoom.Id}\"");
                    return false;
                }


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
                   x.Id,
                   x.ClassName,
                   x.Grade,
                   x.TeacherName,
                   InforStudent = x.InformationStudents.Select(x => new { x.StudentName, x.Gender, x.DateOfBirth, x.Address })
               }).FirstOrDefault();
                if (result != null)
                {
                    _logger.LogInformation($"Show information of Class : \"{result.ClassName}\"");
                    return result;
                }
                _logger.LogInformation($"Show information of Class with id : \"{result.Id}\"");
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
                _logger.LogInformation($"Update ClassName : \"{updateClass.ClassName} \" with id: \"{updateClass.Id}\" successfully ");

                return true;
            }
            _logger.LogInformation($"Cannot Update Class ");
            return false;
        }
    }
}
