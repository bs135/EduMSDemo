using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ISubjectService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SubjectView> GetViews();
        IQueryable<DepartmentView> GetDepartmentViews();

        void Create(SubjectView view);
        void Edit(SubjectView view);
        void Delete(Int32 id);

    }
}
