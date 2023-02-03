﻿using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Validation;
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
            var markList = await _unitOfWork.MarkRepository.GetAllAsync();
            var dupMark = markList.Where(x => x.typeOfMark!.Contains(createMarkDTO.typeOfMark!) && x.StudentId.Equals(createMarkDTO.StudentId) && x.SubjectId.Equals(createMarkDTO.SubjectId));
            if (dupMark.Any())
            {
                throw new Exception("hs nay da co diem o hang muc nay roi");
            }
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
                var markList = await _unitOfWork.MarkRepository.GetAllAsync();
                var dupMark = markList.Where(x => x.typeOfMark!.Contains(updateMarkDTO.typeOfMark!) && x.StudentId.Equals(updateMarkDTO.StudentId) && x.SubjectId.Equals(updateMarkDTO.SubjectId));
                if (dupMark.Any())
                {
                    //throw new Exception("hs nay da co diem o hang muc nay roi");
                    return false;
                }
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

        public async Task<IPagedList<InforMark>> GetMarkPagedList(RequestPaginate requestPaginate)
        {
            List<string> include = new List<string> { "InformationStudent", "InformationSubject" };
            var markList = await _unitOfWork.MarkRepository.GetPagedList(requestPaginate, include);
            return markList;
        }

        public async Task<object> GetAverageMarkOfOneStudent(int id, int semester)
        {
            List<string> include = new List<string> { "InformationStudent", "InformationSubject" };
            var mark = await _unitOfWork.MarkRepository.GetAllAsync(include);
            var result = mark.Where(x => x.InformationStudent.Id == id 
                                    && x.InformationSubject.Semester == semester)
                .Select(x=> new {x.InformationStudent.StudentName
                , x.InformationSubject.SubjectName
                , average = mark.Average(x=>x.Mark)}).FirstOrDefault();
            return result;

        }

        public async Task<object> GetAverageMarkOnASubjectInOneClass(string subjectName, int classId, int semester)
        {
            List<string> include = new List<string> { "InformationStudent", "InformationSubject" };
            var mark = await _unitOfWork.MarkRepository.GetAllAsync(include);
            var result = mark.Where(x => x.InformationStudent.ClassId == classId 
                                    && x.InformationSubject.Semester == semester
                                    && x.InformationSubject.SubjectName.Equals(subjectName))
                .Select(x => new {
                    x.InformationStudent.StudentName
                    ,x.InformationSubject.SubjectName
                    ,average = mark.Average(x => x.Mark)}).FirstOrDefault();
            return result;
        }
    }
}
