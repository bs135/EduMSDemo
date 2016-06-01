using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Department, TView>(id);
        }

        public IQueryable<DepartmentView> GetViews()
        {
            return UnitOfWork
                .Select<Department>()
                .To<DepartmentView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<FacultyView> GetFacultyViews()
        {
            return UnitOfWork
                .Select<Faculty>()
                .To<FacultyView>()
                .OrderByDescending(o => o.Id);
        }

        public void Create(DepartmentView view)
        {
            Department o = UnitOfWork.To<Department>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(DepartmentView view)
        {
            Department o = UnitOfWork.Get<Department>(view.Id);
            o.Address = view.Address;
            o.Email = view.Email;
            o.PhoneNumber = view.PhoneNumber;
            o.FaxNumber = view.FaxNumber;
            o.FacultyId = view.FacultyId;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Department>(id);
            UnitOfWork.Commit();
        }

    }
}
