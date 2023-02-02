﻿using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Model;
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

        public Task<InforStudent> GetDetailStudent(int id)
        {
            if (id > 0)
            {
              var detailStudent =  _unitOfWork.StudentRepository.Get(id);
                if(detailStudent !=null)
                {
                    return detailStudent;
                }
                return null;
            }
            return null;
        }

        public Task<IPagedList<InforStudent>> GetStudentPagedList(RequestPaginate requestPaginate)
        {
            throw new NotImplementedException();
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