using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ICurriculumService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CurriculumView> GetViews();

        IQueryable<FacultyView> GetFacultyViews();
        IQueryable<CourseView> GetCourseViews();
        void Create(CurriculumView view);
        void Edit(CurriculumView view);
        void Delete(Int32 id);

    }
}
