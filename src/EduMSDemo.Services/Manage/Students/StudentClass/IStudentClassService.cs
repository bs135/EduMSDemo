using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IStudentClassService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<StudentClassView> GetViews();
        IQueryable<CourseView> GetCourseViews();
        IQueryable<StaffView> GetStaffViews();

        void Create(StudentClassView view);
        void Edit(StudentClassView view);
        void Delete(Int32 id);

    }
}
