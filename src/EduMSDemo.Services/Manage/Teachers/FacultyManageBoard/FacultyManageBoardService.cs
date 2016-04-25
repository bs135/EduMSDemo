using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;

namespace EduMSDemo.Services
{
    public class FacultyManageBoardService : BaseService, IFacultyManageBoardService
    {
        public FacultyManageBoardService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<FacultyManageBoard, TView>(id);
        }

        public IQueryable<FacultyManageBoardView> GetViews()
        {
            return UnitOfWork
                .Select<FacultyManageBoard>()
                .To<FacultyManageBoardView>()
                .OrderByDescending(o => o.Id);
        }
        public IQueryable<StaffView> GetStaffViews()
        {
            return UnitOfWork
                .Select<Staff>()
                .To<StaffView>()
                .OrderByDescending(model => model.Id);
        }


        public void Create(FacultyManageBoardView view)
        {
            FacultyManageBoard o = UnitOfWork.To<FacultyManageBoard>(view);
            UnitOfWork.Insert(o);
            UnitOfWork.Commit();
        }

        public void Edit(FacultyManageBoardView view)
        {
            FacultyManageBoard o = UnitOfWork.Get<FacultyManageBoard>(view.Id);
            o.StartDate = view.StartDate;
            o.EndDate = view.EndDate;
            o.DeanId = view.DeanId;
            o.ViceDean1Id = view.ViceDean1Id;
            o.ViceDean2Id = view.ViceDean2Id;

            UnitOfWork.Update(o);
            UnitOfWork.Commit();
        }

        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<FacultyManageBoard>(id);
            UnitOfWork.Commit();
        }

    }
}
