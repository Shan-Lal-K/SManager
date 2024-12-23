using AutoMapper;
using STUDMANAG.DTO;
using STUDMANAG.Modal;

namespace STUDMANAG.SISMapping
{
    public class SISAutoMapperProfile : Profile
    {
        public SISAutoMapperProfile()
        {
            CreateMap<AspUsers, AspUsersDto>();
            CreateMap<AspRoles, RoleDto>();
            CreateMap<AspUserRoleDetailsEntity, AspUserRoleDetailsEntity>();
            CreateMap<ClassDetailsEntity, ClassDetailsDto>();
            CreateMap<ExamDetails, ExamDetailsDto>();
            CreateMap<Exam, ExamDto>();
            CreateMap<PrincipalEntity, PrincipalDto>();
            CreateMap<SchoolEntity, SchoolDto>();
            CreateMap<StudentAcademicDetail, StudentAcademicDetailDto>();
            CreateMap<StudentEntity, StudentDto>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<TeacherEntity, TeacherDto>();
            CreateMap<TeacherSubjectDetails, TeacherSubjectDetailsDto>();
        }
    }
}
