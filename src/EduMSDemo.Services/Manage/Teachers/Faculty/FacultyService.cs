using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class FacultyService : BaseService, IFacultyService
    {
        public FacultyService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Faculty, TView>(id);
        }

        public IQueryable<FacultyView> GetViews()
        {
            return UnitOfWork
                .Select<Faculty>()
                .To<FacultyView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(FacultyView view)
        {
            Faculty o = UnitOfWork.To<Faculty>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(FacultyView view)
        {
            Faculty o = UnitOfWork.Get<Faculty>(view.Id);
            o.Name = view.Name;
            o.Abbreviation = view.Abbreviation;
            o.Address = view.Address;
            o.Email = view.Email;
            o.PhoneNumber = view.PhoneNumber;
            o.FaxNumber = view.FaxNumber;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Faculty>(id);
            UnitOfWork.Commit();
        }

    }
}
