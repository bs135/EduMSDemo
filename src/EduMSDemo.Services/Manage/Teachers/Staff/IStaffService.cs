using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IStaffService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<StaffView> GetViews();
        IQueryable<DepartmentView> GetDepartmentViews();
        IQueryable<AccountView> GetAccountViews();

        void Create(StaffView view);
        void Edit(StaffView view);
        void Delete(Int32 id);

    }
}
