using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;

namespace SampleSchoolManagermentV1.Services
{
    public class TimeTableService : ITimeTableService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TimeTableService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InforTimeTable>> GetAllTimeTable()
        {
            var listTime = await _unitOfWork.TimeTableRepository.GetAll();
            return (List<InforTimeTable>)listTime;
        }

        public async Task<InforTimeTable> GetInforTimeTable(int id)
        {
            if(id > 0)
            {
                var result = await _unitOfWork.TimeTableRepository.Get(id);
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            return null;
           
        }
        public async Task<bool> CreateTimeTable(CreateTimeTableDTO createTimeTableDTO)
        {
            if(createTimeTableDTO == null)
            {
                return false;
            }
            var newTimetable = _mapper.Map<InforTimeTable>(createTimeTableDTO);
            await _unitOfWork.TimeTableRepository.Add(newTimetable);
            _unitOfWork.Complete();
            return true;
        }

        public async Task<bool> DeleteTimeTable(int id)
        {
            if(id > 0)
            {
                var result = await _unitOfWork.TimeTableRepository.Get(id);
                if(result != null)
                {
                    _unitOfWork.TimeTableRepository.Delete(result);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            return false;
        }

     

        public async Task<bool> UpdateTimeTable(int id, UpdateTimeTableDTO updateTimeTableDTO)
        {
            if (id > 0)
            {
                var result = await _unitOfWork.TimeTableRepository.Get(id);
                if (result != null)
                {
                    _mapper.Map(updateTimeTableDTO, result);
                    _unitOfWork.TimeTableRepository.Update(result);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
