using AutoMapper;
using EduMSDemo.Objects;
using System.Collections.Generic;

namespace EduMSDemo.Data.Mapping
{
    public class ObjectMapper
    {
        public static void MapObjects()
        {
            Mapper.Initialize(configuration => new ObjectMapper(configuration).Map());
        }

        private IMapperConfiguration Configuration { get; set; }

        private ObjectMapper(IMapperConfiguration configuration)
        {
            Configuration = configuration;
        }

        private void Map()
        {
            MapRoles();
            MapAccounts();
            MapBuildings();
            MapCurriculums();
            MapScores();
            MapStudents();
            MapStudies();
            MapSubjects();
            MapTeachers();

            //Mapper.Configuration.Seal();
        }

        #region Administration

        private void MapRoles()
        {
            Configuration.CreateMap<Role, RoleView>()
                .ForMember(role => role.Permissions, member => member.Ignore());
            Configuration.CreateMap<RoleView, Role>()
                .ForMember(role => role.Permissions, member => member.UseValue(new List<RolePermission>()));
        }
        private void MapAccounts()
        {
            Configuration.CreateMap<Account, AccountView>();
            Configuration.CreateMap<Account, AccountEditView>();
            Configuration.CreateMap<Account, ProfileEditView>();

            Configuration.CreateMap<AccountCreateView, Account>();
            Configuration.CreateMap<AccountRegisterView, Account>();

            Configuration.CreateMap<Account, AccountDeleteView>();


            Configuration.CreateMap<SystemSetting, SystemSettingView>();
            Configuration.CreateMap<SystemSettingView, SystemSetting>();
        }

        #endregion

        #region Buildings
        private void MapBuildings()
        {
            Configuration.CreateMap<Building, BuildingView>();
            Configuration.CreateMap<BuildingView, Building>();

            Configuration.CreateMap<ClassRoom, ClassRoomView>();
            Configuration.CreateMap<ClassRoomView, ClassRoom>();
        }
        #endregion

        #region Curriculums
        private void MapCurriculums()
        {
            Configuration.CreateMap<Curriculum, CurriculumView>();
            Configuration.CreateMap<CurriculumView, Curriculum>();

            Configuration.CreateMap<CurriculumDetail, CurriculumDetailView>();
            Configuration.CreateMap<CurriculumDetailView, CurriculumDetail>();

            Configuration.CreateMap<CurriculumType, CurriculumTypeView>();
            Configuration.CreateMap<CurriculumTypeView, CurriculumType>();
        }
        #endregion

        #region Scores
        private void MapScores()
        {
            Configuration.CreateMap<BonusScore, BonusScoreView>();
            Configuration.CreateMap<BonusScoreView, BonusScore>();

            Configuration.CreateMap<ScoreRecord, ScoreRecordView>();
            Configuration.CreateMap<ScoreRecordView, ScoreRecord>();

            Configuration.CreateMap<ScoreRecordDetail, ScoreRecordDetailView>();
            Configuration.CreateMap<ScoreRecordDetailView, ScoreRecordDetail>();
        }
        #endregion

        #region Students
        private void MapStudents()
        {
            Configuration.CreateMap<Course, CourseView>();
            Configuration.CreateMap<CourseView, Course>();

            Configuration.CreateMap<Student, StudentView>();
            Configuration.CreateMap<StudentView, Student>();

            Configuration.CreateMap<StudentClass, StudentClassView>();
            Configuration.CreateMap<StudentClassView, StudentClass>();

            Configuration.CreateMap<StudentCreateView, Student>();
            Configuration.CreateMap<StudentCreateView, AccountCreateView>();

            Configuration.CreateMap<Student, StudentEditView>();
            Configuration.CreateMap<StudentEditView, AccountEditView>();
            Configuration.CreateMap<Student, AccountEditView>();
        }
        #endregion

        #region Studies
        private void MapStudies()
        {
            Configuration.CreateMap<Semester, SemesterView>();
            Configuration.CreateMap<SemesterView, Semester>();

            Configuration.CreateMap<SubjectClass, SubjectClassView>();
            Configuration.CreateMap<SubjectClassView, SubjectClass>();

            Configuration.CreateMap<SubjectClassTeacher, SubjectClassTeacherView>();
            Configuration.CreateMap<SubjectClassTeacherView, SubjectClassTeacher>();
        }
        #endregion

        #region Subjects
        private void MapSubjects()
        {
            Configuration.CreateMap<Subject, SubjectView>();
            Configuration.CreateMap<SubjectView, Subject>();

            Configuration.CreateMap<PreSubject, PreSubjectView>();
            Configuration.CreateMap<PreSubjectView, PreSubject>();
        }
        #endregion

        #region Teachers
        private void MapTeachers()
        {
            Configuration.CreateMap<Department, DepartmentView>();
            Configuration.CreateMap<DepartmentView, Department>();

            Configuration.CreateMap<Faculty, FacultyView>();
            Configuration.CreateMap<FacultyView, Faculty>();

            Configuration.CreateMap<FacultyManageBoard, FacultyManageBoardView>();
            Configuration.CreateMap<FacultyManageBoardView, FacultyManageBoard>();

            Configuration.CreateMap<Staff, StaffView>();
            Configuration.CreateMap<StaffView, Staff>();
        }
        #endregion
    }
}
