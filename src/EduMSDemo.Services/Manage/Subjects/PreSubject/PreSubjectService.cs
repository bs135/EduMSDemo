using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class PreSubjectService : BaseService, IPreSubjectService
    {
        public PreSubjectService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<PreSubject, TView>(id);
        }

        public IQueryable<PreSubjectView> GetViews()
        {
            return UnitOfWork
                .Select<PreSubject>()
                .To<PreSubjectView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<SubjectView> GetSubjectViews()
        {
            return UnitOfWork
                .Select<Subject>()
                .To<SubjectView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(PreSubjectView view)
        {
            PreSubject o = UnitOfWork.To<PreSubject>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(PreSubjectView view)
        {
            PreSubject o = UnitOfWork.Get<PreSubject>(view.Id);
            o.PreOfSubjectId = view.PreOfSubjectId;
            o.SubjectOfPreId = view.SubjectOfPreId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<PreSubject>(id);
            UnitOfWork.Commit();
        }

    }
}
