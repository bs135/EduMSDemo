using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private IHasher Hasher { get; set; }
        private IAccountService AAccountService { get; set; }
        public StudentService(IUnitOfWork unitOfWork, IHasher hasher)
            : base(unitOfWork)
        {
            Hasher = hasher;
            AAccountService = new AccountService(unitOfWork, hasher);
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Student, TView>(id);
        }

        public StudentEditView GetEditView(Int32 id)
        {
            StudentEditView view = this.Get<StudentEditView>(id);

            if (view != null)
            {
                AccountEditView accView = AAccountService.Get<AccountEditView>(view.AccountId);

                if (accView != null)
                {
                    view.Username = accView.Username;
                    view.Email = accView.Email;
                    view.IsLocked = accView.IsLocked;
                }
            }
            return view;
        }

        public IQueryable<StudentView> GetViews()
        {
            return UnitOfWork
                .Select<Student>()
                .To<StudentView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<AccountView> GetAccountViews()
        {
            return UnitOfWork
                .Select<Account>()
                .To<AccountView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<StudentClassView> GetStudentClassViews()
        {
            return UnitOfWork
                .Select<StudentClass>()
                .To<StudentClassView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(StudentCreateView view)
        {
            AccountCreateView accView = UnitOfWork.To<AccountCreateView>(view);
            Student student = UnitOfWork.To<Student>(view);

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

        public void Edit(StudentEditView view)
        {
            Student student = UnitOfWork.Get<Student>(view.Id);
            if (student != null)
            {
                student.Code = view.Code;
                student.Name = view.Name;
                student.DateOfBirth = view.DateOfBirth;
                student.PlaceOfBirth = view.PlaceOfBirth;
                student.Gender = view.Gender;
                student.Address = view.Address;
                student.PhoneNumber = view.PhoneNumber;
                //student.AccountId = view.AccountId;
                student.StudentClassId = view.StudentClassId;

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
            Student student = UnitOfWork.Get<Student>(id);
            Int32 accId = student.AccountId;
            UnitOfWork.Delete<Student>(id);
            UnitOfWork.Commit();

            UnitOfWork.Delete<Account>(accId);
            UnitOfWork.Commit();
        }

    }
}
