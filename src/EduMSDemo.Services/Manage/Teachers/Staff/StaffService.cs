using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class StaffService : BaseService, IStaffService
    {
        public StaffService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Staff, TView>(id);
        }

        public IQueryable<StaffView> GetViews()
        {
            return UnitOfWork
                .Select<Staff>()
                .To<StaffView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<DepartmentView> GetDepartmentViews()
        {
            return UnitOfWork
                .Select<Department>()
                .To<DepartmentView>()
                .OrderByDescending(model => model.Id);
        }

        public IQueryable<AccountView> GetAccountViews()
        {
            return UnitOfWork
                .Select<Account>()
                .To<AccountView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(StaffView view)
        {
            Staff o = UnitOfWork.To<Staff>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(StaffView view)
        {
            Staff o = UnitOfWork.Get<Staff>(view.Id);
            o.Name = view.Name;
            o.Code = view.Code;
            o.DateOfBirth = view.DateOfBirth;
            o.PlaceOfBirth = view.PlaceOfBirth;
            o.Gender = view.Gender;
            o.Address = view.Address;
            o.PhoneNumber = view.PhoneNumber;
            o.AccountId = view.AccountId;
            o.DepartmentId = view.DepartmentId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Staff>(id);
            UnitOfWork.Commit();
        }

    }
}
