using AutoMapper;
using SampleSchoolManagermentV1.Datas;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;
using System.Xml;
using X.PagedList;

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

        public async Task<object> GetInforTimeTableOfOneClass(int id)
        {
            List<string> include = new List<string> { "InformationSubject", "InformationClass" };
            var timeTableList = await _unitOfWork.TimeTableRepository.GetAllAsync(include);
            if (timeTableList.Any())
            {
                var result = timeTableList.Where(x => x.Classid == id)
               .Select(x => new
               {
                   x.Day,
                   x.slot,
                   x.InformationSubject.SubjectName,
                   x.InformationSubject.Grade,
                   x.InformationClass.ClassName,
                   x.InformationClass.TeacherName
               }).ToList();
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
            var timeTableLList = await _unitOfWork.TimeTableRepository.GetAllAsync();

            var twoSubInOneSlot = timeTableLList
                .Where(x => x.slot.Equals(createTimeTableDTO.slot) 
                && x.Day!.Contains(createTimeTableDTO.Day!)
                && x.Classid.Equals(createTimeTableDTO.Classid));

            var dupSubjectIn1Day = timeTableLList
                .Where(x => x.Day!.Contains(createTimeTableDTO.Day!) 
                && x.SubjectId.Equals(createTimeTableDTO.SubjectId)
                && x.Classid.Equals(createTimeTableDTO.Classid));

            if (dupSubjectIn1Day.Any())
            {
                throw new Exception("Da co tiet hoc nay cua lop nay trong ngay, khong the tao moi");
            }
            if (twoSubInOneSlot.Any())
            {
                throw new Exception("Da co tiet hoc trong slot nay cua lop nay, khong the tao moi");
            }
            if (createTimeTableDTO == null)
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
            if (id > 0)
            {
                var result = await _unitOfWork.TimeTableRepository.Get(id);
                if (result != null)
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
                var timeTableLList = await _unitOfWork.TimeTableRepository.GetAllAsync();
                var twoSubInOneSlot = timeTableLList
                    .Where( x=> x.Day!.Contains(updateTimeTableDTO.Day!) 
                    && x.Classid.Equals(updateTimeTableDTO.Classid)
                    && (x.slot.Equals(updateTimeTableDTO.slot) 
                            || x.SubjectId.Equals(updateTimeTableDTO.SubjectId)));

                //var dupSubjectIn1Day = timeTableLList
                //    .Where(x => x.Day!.Contains(updateTimeTableDTO.Day!) 
                //    && x.SubjectId.Equals(updateTimeTableDTO.SubjectId) 
                //    && x.Classid.Equals(updateTimeTableDTO.Classid));

                if (twoSubInOneSlot.Any())
                {
                    throw new Exception("Da co tiet hoc trong slot nay, khong the update");
                    //return false;
                }
                //else if (dupSubjectIn1Day.Any())
                //{
                //    throw new Exception("Da co tiet hoc nay trong ngay, khong the update");
                //    //return false;
                //}


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

        public async Task<object> GetTimetablePagedList(RequestPaginate requestPaginate)
        {
            List<string> include = new List<string> { "InformationSubject", "InformationClass" };
            var timetable = await _unitOfWork.TimeTableRepository.GetPagedList(requestPaginate, include);
            if (timetable.Any())
            {
                var result = timetable
               .Select(x => new
               {
                   x.Day,
                   x.slot,
                   x.InformationSubject.SubjectName,
                   x.InformationSubject.Grade,
                   x.InformationClass.ClassName,
                   x.InformationClass.TeacherName
               }).ToList();
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
