using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IStudentService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<StudentView> GetViews();
        IQueryable<AccountView> GetAccountViews();
        IQueryable<StudentClassView> GetStudentClassViews();
        void Create(StudentView view);
        void Edit(StudentView view);
        void Delete(Int32 id);

    }
}
