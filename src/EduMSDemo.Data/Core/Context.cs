using EduMSDemo.Data.Mapping;
using EduMSDemo.Objects;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EduMSDemo.Data.Core
{
    public class Context : DbContext
    {
        #region Administration

        protected DbSet<Role> Roles { get; set; }
        protected DbSet<Account> Accounts { get; set; }
        protected DbSet<Permission> Permissions { get; set; }
        protected DbSet<RolePermission> RolePermissions { get; set; }
        protected DbSet<SystemSetting> SystemSettings { get; set; }
        #endregion

        #region System

        protected DbSet<AuditLog> AuditLogs { get; set; }

        #endregion

        #region Building
        protected DbSet<Building> Buildings { get; set; }
        protected DbSet<ClassRoom> ClassRooms { get; set; }
        #endregion

        #region Curriculum
        protected DbSet<Curriculum> Curriculums { get; set; }
        protected DbSet<CurriculumDetail> CurriculumDetails { get; set; }
        protected DbSet<CurriculumType> CurriculumTypes { get; set; }
        #endregion

        #region Scores
        protected DbSet<BonusScore> BonusScores { get; set; }
        protected DbSet<ScoreRecord> ScoreRecords { get; set; }
        protected DbSet<ScoreRecordDetail> ScoreRecordDetails { get; set; }
        #endregion

        #region Students
        protected DbSet<Course> Courses { get; set; }
        protected DbSet<Student> Students { get; set; }
        protected DbSet<StudentClass> StudentClasses { get; set; }
        #endregion

        #region Studies
        protected DbSet<Semester> Semesters { get; set; }
        protected DbSet<SubjectClass> SubjectClasses { get; set; }
        #endregion

        #region Subjects
        protected DbSet<PreSubject> PreSubjects { get; set; }
        protected DbSet<Subject> Subjects { get; set; }
        #endregion

        #region Teacher

        protected DbSet<Staff> Staffs { get; set; }
        protected DbSet<Faculty> Faculties { get; set; }
        protected DbSet<FacultyManageBoard> FacultyManageBoards { get; set; }
        protected DbSet<Department> Departments { get; set; }

        #endregion

        static Context()
        {
            ObjectMapper.MapObjects();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties<DateTime>().Configure(config => config.HasColumnType("datetime2"));
            modelBuilder.Entity<Permission>().Property(model => model.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
