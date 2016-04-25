using LightInject;
using EduMSDemo.Components.Logging;
using EduMSDemo.Components.Mail;
using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Controllers;
using EduMSDemo.Data.Core;
using EduMSDemo.Data.Logging;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System.Data.Entity;
using System.Web.Hosting;
using System.Web.Mvc;

namespace EduMSDemo.Web.DependencyInjection
{
    public class MainContainer : ServiceContainer
    {
        public void RegisterServices()
        {
            Register<DbContext, Context>();
            Register<IUnitOfWork, UnitOfWork>();

            Register<ILogger, Logger>();
            Register<IAuditLogger, AuditLogger>();

            Register<IHasher, BCrypter>();
            Register<IMailClient, SmtpMailClient>();

            Register<IRouteConfig, RouteConfig>();
            Register<IBundleConfig, BundleConfig>();
            //Register<IExceptionFilter, ExceptionFilter>();

            Register<IMvcSiteMapParser, MvcSiteMapParser>();
            Register<IMvcSiteMapProvider>(factory => new MvcSiteMapProvider(
                 HostingEnvironment.MapPath("~/Mvc.sitemap"), factory.GetInstance<IMvcSiteMapParser>()));

            Register<IGlobalizationProvider>(factory =>
                new GlobalizationProvider(HostingEnvironment.MapPath("~/Globalization.xml")));
            RegisterInstance<IAuthorizationProvider>(new AuthorizationProvider(typeof(BaseController).Assembly));

            // service

            #region Admin service
            Register<IRoleService, RoleService>();
            Register<IAccountService, AccountService>();
            Register<ISystemSettingService, SystemSettingService>();
            #endregion

            #region Product service
            Register<IProductService, ProductService>();
            Register<IProductGroupService, ProductGroupService>();
            #endregion

            #region Buildings service
            Register<IBuildingService, BuildingService>();
            Register<IClassRoomService, ClassRoomService>();
            #endregion

            #region Curriculums service
            Register<ICurriculumDetailService, CurriculumDetailService>();
            Register<ICurriculumService, CurriculumService>();
            Register<ICurriculumTypeService, CurriculumTypeService>();
            #endregion

            #region Scores service
            Register<IBonusScoreService, BonusScoreService>();
            Register<IScoreRecordDetailService, ScoreRecordDetailService>();
            Register<IScoreRecordService, ScoreRecordService>();
            #endregion

            #region Students service
            Register<ICourseService, CourseService>();
            Register<IStudentClassService, StudentClassService>();
            Register<IStudentService, StudentService>();
            #endregion

            #region Studies service
            Register<ISemesterService, SemesterService>();
            Register<ISubjectClassService, SubjectClassService>();
            Register<ISubjectClassTeacherService, SubjectClassTeacherService>();
            #endregion

            #region Subjects service
            Register<IPreSubjectService, PreSubjectService>();
            Register<ISubjectService, SubjectService>();
            #endregion

            #region Teachers service
            Register<IDepartmentService, DepartmentService>();
            Register<IFacultyService, FacultyService>();
            Register<IFacultyManageBoardService, FacultyManageBoardService>();
            Register<IStaffService, StaffService>();
            #endregion

            // Validator

            #region Admin validator
            Register<IRoleValidator, RoleValidator>();
            Register<IAccountValidator, AccountValidator>();
            Register<ISystemSettingValidator, SystemSettingValidator>();
            #endregion

            #region Product validator
            Register<IProductValidator, ProductValidator>();
            Register<IProductGroupValidator, ProductGroupValidator>();
            #endregion

            #region Buildings validator
            Register<IBuildingValidator, BuildingValidator>();
            Register<IClassRoomValidator, ClassRoomValidator>();
            #endregion

            #region Curriculums validator
            Register<ICurriculumValidator, CurriculumValidator>();
            Register<ICurriculumDetailValidator, CurriculumDetailValidator>();
            Register<ICurriculumTypeValidator, CurriculumTypeValidator>();
            #endregion

            #region Scores validator
            Register<IBonusScoreValidator, BonusScoreValidator>();
            Register<IScoreRecordDetailValidator, ScoreRecordDetailValidator>();
            Register<IScoreRecordValidator, ScoreRecordValidator>();
            #endregion

            #region Students validator
            Register<ICourseValidator, CourseValidator>();
            Register<IStudentClassValidator, StudentClassValidator>();
            Register<IStudentValidator, StudentValidator>();
            #endregion

            #region Studies validator
            Register<ISemesterValidator, SemesterValidator>();
            Register<ISubjectClassValidator, SubjectClassValidator>();
            Register<ISubjectClassTeacherValidator, SubjectClassTeacherValidator>();
            #endregion

            #region Subjects validator
            Register<IPreSubjectValidator, PreSubjectValidator>();
            Register<ISubjectValidator, SubjectValidator>();
            #endregion

            #region Teachers validator
            Register<IDepartmentValidator, DepartmentValidator>();
            Register<IFacultyValidator, FacultyValidator>();
            Register<IFacultyManageBoardValidator, FacultyManageBoardValidator>();
            Register<IStaffValidator, StaffValidator>();
            #endregion
        }
    }
}
