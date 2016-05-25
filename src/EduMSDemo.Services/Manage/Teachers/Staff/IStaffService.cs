using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IStaffService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        StaffEditView GetEditView(Int32 id);
        IQueryable<StaffView> GetViews();
        IQueryable<AccountView> GetAccountViews();
        IQueryable<DepartmentView> GetDepartmentViews();
        void Create(StaffCreateView view);
        void Edit(StaffEditView view);
        void Delete(Int32 id);

    }
}
