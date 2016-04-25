using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface ISubjectClassService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SubjectClassView> GetViews();
        IQueryable<ClassRoomView> GetClassRoomViews();
        IQueryable<SemesterView> GetSemesterViews();
        void Create(SubjectClassView view);
        void Edit(SubjectClassView view);
        void Delete(Int32 id);

    }
}
