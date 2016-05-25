using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IStudentService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        StudentEditView GetEditView(Int32 id);
        IQueryable<StudentView> GetViews();
        IQueryable<AccountView> GetAccountViews();
        IQueryable<StudentClassView> GetStudentClassViews();
        void Create(StudentCreateView view);
        void Edit(StudentEditView view);
        void Delete(Int32 id);

    }
}
