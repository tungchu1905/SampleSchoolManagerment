﻿using AutoMapper;
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

        public async Task<object> GetInforTimeTable(int id)
        {
            List<string> include = new List<string> { "InformationSubject" };
            var timeTableList = await _unitOfWork.TimeTableRepository.GetAllAsync(include);
            if (timeTableList.Any())
            {
                var result = timeTableList.Where(x => x.Id == id)
               .Select(x => new
               {
                   x.Day,
                   x.slot,
                   x.InformationSubject
               }).FirstOrDefault();
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
            var twoSubInOneSlot = timeTableLList.Where(x => x.slot.Equals(createTimeTableDTO.slot) && x.Day!.Contains(createTimeTableDTO.Day!));
            var dupSubjectIn1Day = timeTableLList.Where(x => x.Day!.Contains(createTimeTableDTO.Day!) && x.SubjectId.Equals(createTimeTableDTO.SubjectId));
            if (dupSubjectIn1Day.Any())
            {
                throw new Exception("Da co tiet hoc nay trong ngay");
            }
            if (twoSubInOneSlot.Any())
            {
                throw new Exception("Da co tiet hoc trong slot nay");
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
                //var timeTableLList = await _unitOfWork.TimeTableRepository.GetAllAsync();
                //var twoSubInOneSlot = timeTableLList.Where(x => x.slot.Equals(updateTimeTableDTO.slot) && x.Day!.Contains(updateTimeTableDTO.Day!));
                //var dupSubjectIn1Day = timeTableLList.Where(x => x.Day!.Contains(updateTimeTableDTO.Day!) && x.SubjectId.Equals(updateTimeTableDTO.SubjectId));
                //if (dupSubjectIn1Day.Any())
                //{
                //    throw new Exception("Da co tiet hoc nay trong ngay");
                //    //return false;
                //}
                //if (twoSubInOneSlot.Any())
                //{
                //    throw new Exception("Da co tiet hoc trong slot nay");
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

        public async Task<IPagedList<InforTimeTable>> GetTimetablePagedList(RequestPaginate requestPaginate)
        {
            List<string> include = new List<string> { "InformationSubject" };
            var timetable = await _unitOfWork.TimeTableRepository.GetPagedList(requestPaginate, include);
            return timetable;
            
        }

        
    }
}
