using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ISubjectClassTeacherService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SubjectClassTeacherView> GetViews();
        IQueryable<SubjectClassView> GetSubjectClassViews();
        IQueryable<StaffView> GetStaffViews();

        void Create(SubjectClassTeacherView view);
        void Edit(SubjectClassTeacherView view);
        void Delete(Int32 id);

    }
}
