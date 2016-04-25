using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IFacultyManageBoardService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<FacultyManageBoardView> GetViews();
        IQueryable<StaffView> GetStaffViews();

        void Create(FacultyManageBoardView view);
        void Edit(FacultyManageBoardView view);
        void Delete(Int32 id);

    }
}
