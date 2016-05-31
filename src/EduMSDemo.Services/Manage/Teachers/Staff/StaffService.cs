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
        private IHasher Hasher { get; set; }
        private IAccountService AAccountService { get; set; }
        public StaffService(IUnitOfWork unitOfWork, IHasher hasher)
            : base(unitOfWork)
        {
            Hasher = hasher;
            AAccountService = new AccountService(unitOfWork, hasher);
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Staff, TView>(id);
        }

        public StaffEditView GetEditView(Int32 id)
        {
            StaffEditView view = this.Get<StaffEditView>(id);

            if (view != null)
            {
                AccountEditView accView = AAccountService.Get<AccountEditView>(view.AccountId);

                if (accView != null)
                {
                    //view.Username = accView.Username;
                    view.Email = accView.Email;
                    view.IsLocked = accView.IsLocked;
                }
            }
            return view;
        }

        public IQueryable<StaffView> GetViews()
        {
            return UnitOfWork
                .Select<Staff>()
                .To<StaffView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<AccountView> GetAccountViews()
        {
            return UnitOfWork
                .Select<Account>()
                .To<AccountView>()
                .OrderByDescending(o => o.Id);
        }

        public IQueryable<DepartmentView> GetDepartmentViews()
        {
            return UnitOfWork
                .Select<Department>()
                .To<DepartmentView>()
                .OrderByDescending(o => o.Id);
        }


        public void Create(StaffCreateView view)
        {
            AccountCreateView accView = UnitOfWork.To<AccountCreateView>(view);
            accView.Username = view.Code;

            Staff student = UnitOfWork.To<Staff>(view);

            AAccountService.Create(accView);
            UnitOfWork.Commit();

            Account ra = UnitOfWork.Select<Account>().FirstOrDefault(acc => acc.Username == accView.Username);

            if (ra != null)
            {
                student.AccountId = ra.Id;
            }
            UnitOfWork.Insert(student);
            UnitOfWork.Commit();
        }

        public void Edit(StaffEditView view)
        {
            Staff student = UnitOfWork.Get<Staff>(view.Id);
            if (student != null)
            {
                //student.Code = view.Code;
                student.Name = view.Name;
                student.DateOfBirth = view.DateOfBirth;
                student.PlaceOfBirth = view.PlaceOfBirth;
                student.Gender = view.Gender;
                student.Address = view.Address;
                student.PhoneNumber = view.PhoneNumber;
                //student.AccountId = view.AccountId;
                student.DepartmentId = view.DepartmentId;

                UnitOfWork.Update(student);
                UnitOfWork.Commit();

                Account account = UnitOfWork.Get<Account>(student.AccountId);
                if (account != null)
                {
                    account.IsLocked = view.IsLocked;
                    UnitOfWork.Update(account);
                    UnitOfWork.Commit();
                }
            }
        }

        public void Delete(Int32 id)
        {
            Staff student = UnitOfWork.Get<Staff>(id);
            if (student != null)
            {
                Int32 accId = student.AccountId;
                UnitOfWork.Delete<Staff>(id);
                UnitOfWork.Commit();

                UnitOfWork.Delete<Account>(accId);
                UnitOfWork.Commit();
            }
        }

    }
}
