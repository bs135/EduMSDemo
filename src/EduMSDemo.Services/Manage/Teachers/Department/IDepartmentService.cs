using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IDepartmentService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<DepartmentView> GetViews();
        IQueryable<FacultyView> GetFacultyViews();

        void Create(DepartmentView view);
        void Edit(DepartmentView view);
        void Delete(Int32 id);

    }
}
