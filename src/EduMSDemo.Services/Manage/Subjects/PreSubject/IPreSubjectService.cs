using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IPreSubjectService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<PreSubjectView> GetViews();
        IQueryable<SubjectView> GetSubjectViews();

        void Create(PreSubjectView view);
        void Edit(PreSubjectView view);
        void Delete(Int32 id);

    }
}
