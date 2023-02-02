using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Model;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;
using X.PagedList;

namespace SampleSchoolManagermentV1.Services
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ClassService(IMapper mapper, IUnitOfWork unitOfWork) {
                _mapper= mapper;
            _unitOfWork= unitOfWork;
        }

        // read
        public async Task<List<InforClass>> GetAllClass()
        {
            var classes = await _unitOfWork.ClassRepository.GetAll();
            return (List<InforClass>)classes;
        }

        public async Task<IPagedList<InforClass>> GetClassPagedList(RequestPaginate requestPaginate)
        {
            List<string> include = new List<string> { "students.student" };
            var classList = await _unitOfWork.ClassRepository.GetPagedList(requestPaginate,include);
            return classList;
        }

        // create
        public async Task<bool> CraeteClass(CreateClassDTO createClassDTO)
        {
            if(createClassDTO == null)
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
            if(id>0)
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
        public Task<InforClass> GetDetailClass(int id)
        {
            if (id > 0)
            {
                var classRoom = _unitOfWork.ClassRepository.Get(id);
                if(classRoom != null)
                {
                    return classRoom;
                }
                else  return null;
            }
            return null;
        }

        // update
        public async Task<bool> UpdateClass(int id, UpdateClassDTO updateClassDTO)
        {
           if(id > 0)
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
