using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ICourseService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CourseView> GetViews();

        IQueryable<FacultyView> GetFacultyViews();
        void Create(CourseView view);
        void Edit(CourseView view);
        void Delete(Int32 id);

    }
}
