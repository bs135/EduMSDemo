using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class CurriculumTypeService : BaseService, ICurriculumTypeService
    {
        public CurriculumTypeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<CurriculumType, TView>(id);
        }

        public IQueryable<CurriculumTypeView> GetViews()
        {
            return UnitOfWork
                .Select<CurriculumType>()
                .To<CurriculumTypeView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(CurriculumTypeView view)
        {
            CurriculumType o = UnitOfWork.To<CurriculumType>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(CurriculumTypeView view)
        {
            CurriculumType o = UnitOfWork.Get<CurriculumType>(view.Id);
            o.Name = view.Name;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<CurriculumType>(id);
            UnitOfWork.Commit();
        }

    }
}
