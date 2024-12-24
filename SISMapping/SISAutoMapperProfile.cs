using AutoMapper;
using STUDMANAG.DTO;
using STUDMANAG.Modal;

namespace STUDMANAG.SISMapping
{
    public class SISAutoMapperProfile : Profile
    {
        public SISAutoMapperProfile()
        {
            CreateMap<AspUsers, AspUsersDto>().ReverseMap();
            CreateMap<AspRoles, RoleDto>().ReverseMap();
            CreateMap<AspUserRoleDetailsEntity, AspUserRoleDetailsEntity>().ReverseMap();
            CreateMap<ClassDetailsEntity, ClassDetailsDto>().ReverseMap();
            CreateMap<ExamDetails, ExamDetailsDto>().ReverseMap();
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<PrincipalEntity, PrincipalDto>().ReverseMap();
            CreateMap<SchoolEntity, SchoolDto>().ReverseMap();
            CreateMap<StudentAcademicDetail, StudentAcademicDetailDto>().ReverseMap();
            CreateMap<StudentEntity, StudentDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<TeacherEntity, TeacherDto>().ReverseMap();
            CreateMap<TeacherSubjectDetails, TeacherSubjectDetailsDto>().ReverseMap();
        }
    }
}
