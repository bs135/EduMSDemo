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
        public StudentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Student, TView>(id);
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

        public void Create(StudentView view)
        {
            Student o = UnitOfWork.To<Student>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(StudentView view)
        {
            Student o = UnitOfWork.Get<Student>(view.Id);
            o.Code = view.Code;
            o.Name = view.Name;
            o.DateOfBirth = view.DateOfBirth;
            o.PlaceOfBirth = view.PlaceOfBirth;
            o.Gender = view.Gender;
            o.Address = view.Address;
            o.PhoneNumber = view.PhoneNumber;
            o.AccountId = view.AccountId;
            o.StudentClassId = view.StudentClassId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Student>(id);
            UnitOfWork.Commit();
        }

    }
}
