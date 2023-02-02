using AutoMapper;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.DTO.User;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Repository.Repositories.Implement;

namespace SampleSchoolManagermentV1.Mapper
{
    public class MapperInitilier : Profile
    {
        public MapperInitilier() {
            CreateMap<InforClass, ClassDTO>().ReverseMap();
            CreateMap<InforClass, CreateClassDTO>().ReverseMap();
            
            CreateMap<InforStudent, StudentDTO>().ReverseMap();
            CreateMap<InforStudent, CreateStudentDTO>().ReverseMap();

            CreateMap<InforSubject, SubjectDTO>().ReverseMap();
            CreateMap<InforSubject, CreateSubjectDTO>().ReverseMap();

            CreateMap<InforMark, MarkDTO>().ReverseMap();
            CreateMap<InforMark, CreateMarkDTO>().ReverseMap();

            CreateMap<InforTimeTable, TimeTableDTO>().ReverseMap();
            CreateMap<InforTimeTable, CreateTimeTableDTO>().ReverseMap();

            //CreateMap<ApplicationUser, UserDTO>().ReverseMap();
            //CreateMap<ApplicationUser, LoginDTO>().ReverseMap();
            //CreateMap<ApplicationUser, SignUpDTO>().ReverseMap();

            
        }
    }
}
