using Microsoft.EntityFrameworkCore;
using STUDMANAG.Modal;

namespace STUDMANAG.SContext
{
    public class SDbcontext : DbContext
    {
        public SDbcontext(DbContextOptions<SDbcontext> options) : base(options) { }
        public DbSet<AspRoles> AspRoles { get; set; }
        public DbSet<AspUserRoleDetailsEntity> AspUserRoleDetails { get; set; }
        public DbSet<AspUsers> AspUsers { get; set; }
        public DbSet<ClassDetailsEntity> ClassDetails { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamDetails> ExamsDetails { get; set; }
        public DbSet<PrincipalEntity> Principals { get; set; }
        public DbSet<SchoolEntity> Schools { get; set; }
        public DbSet<StudentAcademicDetail> StudentAcademicDetails { get; set; }
        public DbSet<StudentEntity> StudentEntities { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<TeacherSubjectDetails> TeacherSubjectDetails { get; set; }

    }
}
